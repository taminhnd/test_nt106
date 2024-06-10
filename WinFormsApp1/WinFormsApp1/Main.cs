using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;

namespace WinFormsApp1
{
    public partial class Main : Form
    {
        private ICaptureDevice deviceIA;
        private ILiveDevice deviceIB;
        private CaptureDeviceList devices = CaptureDeviceList.Instance;
        private List<Packet> packetList = new List<Packet>();
        bool isCapturing = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var dev in devices)
            {
                comboBoxDeviceIA.Items.Add(dev.Description);
                comboBoxDeviceIB.Items.Add(dev.Description);
            }
        }

        private void buttonStartCapture_Click(object sender, EventArgs e)
        {
            if (comboBoxDeviceIA.SelectedIndex == -1 || comboBoxDeviceIB.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both network interfaces.");
                return;
            }

            var devices = CaptureDeviceList.Instance;

            deviceIA = devices[comboBoxDeviceIA.SelectedIndex];
            //deviceIB = devices[comboBoxDeviceIB.SelectedIndex];


            isCapturing = true;
            Task.Run(() => StartPacketCapture());
        }

        private void buttonStopCapture_Click(object sender, EventArgs e)
        {
            if (isCapturing == false || packetList.Count == 0)
            {
                MessageBox.Show("Capture not started.");
                return;
            }

            deviceIA.Close();
            byte[] data = packetList.ElementAt(packetList.Count - 1).PayloadPacket.PayloadPacket.PayloadData;
            string a = Encoding.UTF8.GetString(data);
            //textBox1.Text = a;
            //deviceIB.Close();
            isCapturing = false;
        }

        private void StartPacketCapture()
        {
            try
            {
                deviceIA.Open();
                deviceIA.OnPacketArrival += (sender, e) =>
                {
                    try
                    {
                        var packet = Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data);
                        packetList.Add(packet);

                        if (packet is EthernetPacket ethernetPacket)
                        {
                            if (ethernetPacket.PayloadPacket is IPPacket ipPacket)
                            {
                                if (ipPacket.PayloadPacket is TcpPacket tcpPacket)
                                {
                                    var sourceIp = ipPacket.SourceAddress;
                                    var destinationIp = ipPacket.DestinationAddress;
                                    var sourcePort = tcpPacket.SourcePort;
                                    var destinationPort = tcpPacket.DestinationPort;
                                    var sourceMAC = ethernetPacket.SourceHardwareAddress;
                                    var destinationMAC = ethernetPacket.DestinationHardwareAddress;

                                    if (listViewPackets.InvokeRequired)
                                    {
                                        listViewPackets.Invoke(new MethodInvoker(delegate
                                        {

                                            var item = new ListViewItem(new[]
                                            {
                                                listViewPackets.Items.Count.ToString(),
                                                sourceIp.ToString(),
                                                destinationIp.ToString(),
                                                sourcePort.ToString(),
                                                destinationPort.ToString(),
                                                sourceMAC.ToString(),
                                                destinationMAC.ToString()
                                            });
                                            listViewPackets.Items.Add(item);
                                            listViewPackets.EnsureVisible(listViewPackets.Items.Count - 1);
                                        }));

                                    }
                                    else
                                    {

                                        var item = new ListViewItem(new[]
                                        {
                                            listViewPackets.Items.Count.ToString(),
                                            sourceIp.ToString(),
                                            destinationIp.ToString(),
                                            sourcePort.ToString(),
                                            destinationPort.ToString(),
                                            sourceMAC.ToString(),
                                            destinationMAC.ToString()
                                        });
                                        listViewPackets.Items.Add(item);
                                        listViewPackets.EnsureVisible(listViewPackets.Items.Count - 1);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing packet: {ex.Message}");
                    }
                };

                deviceIA.StartCapture();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error capturing traffic: {ex.Message}");
            }
        }

        bool CorrectInfoFormat(string sourIP, string destIP, string sourPort, string destPort)
        {
            if (!IPAddress.TryParse(sourIP, out IPAddress _) && !string.IsNullOrEmpty(sourIP))
                return false;
            if (!IPAddress.TryParse(destIP, out IPAddress _))
                return false;
            if (!int.TryParse(sourPort, out int _) && !string.IsNullOrEmpty(sourPort))
                return false;
            if (!int.TryParse(destPort, out int _))
                return false;
            return true;
        }

        private string GetLocalSourceIP(ILiveDevice device)
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.Description == device.Description && ni.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            return ip.Address.ToString();
                        }
                    }
                }
            }
            throw new Exception("IP Address Not Found for the selected device!");
        }
        private int GetSourcePort()
        {
            var listener = new System.Net.Sockets.TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
        private bool IsDeviceAvailable(ILiveDevice device)
        {
            try
            {
                device.Open();
                device.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void Send_packet_Click(object sender, EventArgs e)
        {
            if (comboBoxDeviceIA.SelectedIndex == -1 || comboBoxDeviceIB.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both network interfaces.");
                return;
            }

            if (packetList.Count == 0)
            {
                MessageBox.Show("No packets to send.");
                return;
            }

            var devices = CaptureDeviceList.Instance;
            deviceIB = devices[comboBoxDeviceIB.SelectedIndex];

            if (!CorrectInfoFormat(Sour_IP_textBox.Text, Dest_IP_textBox.Text, Sour_Port_textBox.Text, Dest_Port_textBox.Text))
            {
                MessageBox.Show("Enter the correct format for each infomation.");
                return;
            }

            string sentsourceIP = Sour_IP_textBox.Text;
            if (string.IsNullOrWhiteSpace(sentsourceIP))
            {
                sentsourceIP = GetLocalSourceIP(deviceIB);
            }

            string sentdestinationIP = Dest_IP_textBox.Text;
            int sentsourcePort;
            if (string.IsNullOrWhiteSpace(Sour_Port_textBox.Text))
            {
                sentsourcePort = GetSourcePort();
            }
            else
            {
                sentsourcePort = int.Parse(Sour_Port_textBox.Text);
            }

            int sentdestinationPort = int.Parse(Dest_Port_textBox.Text);

            if (!IsDeviceAvailable(deviceIB))
            {
                MessageBox.Show("The selected device is not available.");
                return;
            }

            Task.Run(() => StartSendingPacket(sentsourceIP, sentdestinationIP, sentsourcePort, sentdestinationPort));

        }

        private void StartSendingPacket(string sentsourceIP, string sentdestinationIP, int sentsourcePort, int sentdestinationPort)
        {
            try
            {
                MessageBox.Show("Opening device IB");
                deviceIB.Open();
                if (packetList.Count == 0)
                {
                    Console.WriteLine("Packet list is empty. Nothing to send.");
                    return;
                }

                int packetnumber = 1;
                int sentPacketCount = 0;
                foreach (var packet in packetList)
                {
                    if (packet is EthernetPacket ethernetPacket)
                    {
                        if (ethernetPacket.PayloadPacket is IPPacket ipPacket)
                        {
                            ipPacket.SourceAddress = IPAddress.Parse(sentsourceIP);
                            ipPacket.DestinationAddress = IPAddress.Parse(sentdestinationIP);

                            if (ipPacket.PayloadPacket is TcpPacket tcpPacket)
                            {
                                tcpPacket.SourcePort = (ushort)sentsourcePort;
                                tcpPacket.DestinationPort = (ushort)sentdestinationPort;

                                tcpPacket.UpdateCalculatedValues();
                                ipPacket.UpdateCalculatedValues();
                            }
                            else if (ipPacket.PayloadPacket is UdpPacket udpPacket)
                            {
                                udpPacket.SourcePort = (ushort)sentsourcePort;
                                udpPacket.DestinationPort = (ushort)sentdestinationPort;

                                udpPacket.UpdateCalculatedValues();
                                ipPacket.UpdateCalculatedValues();
                            }
                        }

                        try
                        {
                            deviceIB.SendPacket(ethernetPacket);
                            sentPacketCount++;
                            this.Invoke((MethodInvoker)delegate
                            {
                                sentpacket_counts_label.Text = sentPacketCount.ToString();
                            });
                        }
                        catch (Exception ex)
                        {

                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Packet is not an EthernetPacket.");
                    }
                }
                deviceIB.Close();
                MessageBox.Show("All packets sent");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error sending packets: {ex.Message}");
            }
        }
        private void Center()
        {
            // Tính toán vị trí mới của Panel để nó ở giữa Form
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            listViewPackets.Left = (this.ClientSize.Width - listViewPackets.Width) / 2;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            //Center();
        }


        private void DisplayPacketDetails(Packet packet)
        {
            StringBuilder packetDetails = new StringBuilder();

            if (packet is EthernetPacket ethernetPacket)
            {
                packetDetails.AppendLine("Ethernet Packet:");
                packetDetails.AppendLine($"Source MAC: {ethernetPacket.SourceHardwareAddress}");
                packetDetails.AppendLine($"Destination MAC: {ethernetPacket.DestinationHardwareAddress}");

                if (ethernetPacket.PayloadPacket is IPPacket ipPacket)
                {
                    packetDetails.AppendLine("\nIP Packet:");
                    packetDetails.AppendLine($"Source IP: {ipPacket.SourceAddress}");
                    packetDetails.AppendLine($"Destination IP: {ipPacket.DestinationAddress}");

                    if (ipPacket.PayloadPacket is TcpPacket tcpPacket)
                    {
                        packetDetails.AppendLine("\nTCP Packet:");
                        packetDetails.AppendLine($"Source Port: {tcpPacket.SourcePort}");
                        packetDetails.AppendLine($"Destination Port: {tcpPacket.DestinationPort}");
                        packetDetails.AppendLine($"Payload: {BitConverter.ToString(tcpPacket.PayloadData).Replace("-", " ")}");
                    }
                    else if (ipPacket.PayloadPacket is UdpPacket udpPacket)
                    {
                        packetDetails.AppendLine("\nUDP Packet:");
                        packetDetails.AppendLine($"Source Port: {udpPacket.SourcePort}");
                        packetDetails.AppendLine($"Destination Port: {udpPacket.DestinationPort}");
                        packetDetails.AppendLine($"Payload: {BitConverter.ToString(udpPacket.PayloadData).Replace("-", " ")}");
                    }
                }
            }

            MessageBox.Show(packetDetails.ToString(), "Packet Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void listViewPackets_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewPackets.SelectedItems.Count > 0)
            {
                int selectedIndex = listViewPackets.SelectedItems[0].Index;
                Packet selectedPacket = packetList[selectedIndex];
                DisplayPacketDetails(selectedPacket);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Packet Files|*.pcap",
                Title = "Save Packets"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    var writer = new BinaryWriter(fs);
                    foreach (var packet in packetList)
                    {
                        var data = packet.Bytes;
                        writer.Write(data.Length);
                        writer.Write(data);
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Packet Files|*.pcap",
                Title = "Load Packets"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    var reader = new BinaryReader(fs);
                    packetList.Clear();
                    while (fs.Position < fs.Length)
                    {
                        var length = reader.ReadInt32();
                        var data = reader.ReadBytes(length);
                        var packet = Packet.ParsePacket(LinkLayers.Ethernet, data);
                        packetList.Add(packet);
                        AddPacketToListView(packet);
                    }
                }
            }
        }

        private void AddPacketToListView(Packet packet)
        {
            if (packet is EthernetPacket ethernetPacket)
            {
                if (ethernetPacket.PayloadPacket is IPPacket ipPacket)
                {
                    if (ipPacket.PayloadPacket is TcpPacket tcpPacket)
                    {
                        var item = new ListViewItem(new[]
                        {
                    listViewPackets.Items.Count.ToString(),
                    ipPacket.SourceAddress.ToString(),
                    ipPacket.DestinationAddress.ToString(),
                    tcpPacket.SourcePort.ToString(),
                    tcpPacket.DestinationPort.ToString(),
                    ethernetPacket.SourceHardwareAddress.ToString(),
                    ethernetPacket.DestinationHardwareAddress.ToString()
                });
                        listViewPackets.Items.Add(item);
                        listViewPackets.EnsureVisible(listViewPackets.Items.Count - 1);
                    }
                    else if (ipPacket.PayloadPacket is UdpPacket udpPacket)
                    {
                        var item = new ListViewItem(new[]
                        {
                    listViewPackets.Items.Count.ToString(),
                    ipPacket.SourceAddress.ToString(),
                    ipPacket.DestinationAddress.ToString(),
                    udpPacket.SourcePort.ToString(),
                    udpPacket.DestinationPort.ToString(),
                    ethernetPacket.SourceHardwareAddress.ToString(),
                    ethernetPacket.DestinationHardwareAddress.ToString()
                });
                        listViewPackets.Items.Add(item);
                        listViewPackets.EnsureVisible(listViewPackets.Items.Count - 1);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            listViewPackets.Items.Clear();
            packetList.Clear();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files|*.txt|CSV Files|*.csv",
                Title = "Export Packets"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var packet in packetList)
                    {
                        writer.WriteLine(packet.ToString());
                    }
                }
            }
        }


        private void DisplaySearchResults(List<Packet> searchResults)
        {
            listViewPackets.Items.Clear();
            foreach (var packet in searchResults)
            {
                if (packet is EthernetPacket ethernetPacket)
                {
                    if (ethernetPacket.PayloadPacket is IPPacket ipPacket)
                    {
                        if (ipPacket.PayloadPacket is TcpPacket tcpPacket)
                        {
                            var item = new ListViewItem(new[]
                            {
                        listViewPackets.Items.Count.ToString(),
                        ipPacket.SourceAddress.ToString(),
                        ipPacket.DestinationAddress.ToString(),
                        tcpPacket.SourcePort.ToString(),
                        tcpPacket.DestinationPort.ToString(),
                        ethernetPacket.SourceHardwareAddress.ToString(),
                        ethernetPacket.DestinationHardwareAddress.ToString()
                    });
                            listViewPackets.Items.Add(item);
                        }
                        else if (ipPacket.PayloadPacket is UdpPacket udpPacket)
                        {
                            var item = new ListViewItem(new[]
                            {
                        listViewPackets.Items.Count.ToString(),
                        ipPacket.SourceAddress.ToString(),
                        ipPacket.DestinationAddress.ToString(),
                        udpPacket.SourcePort.ToString(),
                        udpPacket.DestinationPort.ToString(),
                        ethernetPacket.SourceHardwareAddress.ToString(),
                        ethernetPacket.DestinationHardwareAddress.ToString()
                    });
                            listViewPackets.Items.Add(item);
                        }
                    }
                }
            }
            listViewPackets.EnsureVisible(listViewPackets.Items.Count - 1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();
            string searchCriteria = comboBoxSearch.SelectedItem.ToString();

            var searchResults = packetList.Where(packet =>
            {
                if (packet is EthernetPacket ethernetPacket)
                {
                    if (ethernetPacket.PayloadPacket is IPPacket ipPacket)
                    {
                        if (ipPacket.PayloadPacket is TcpPacket tcpPacket)
                        {
                            switch (searchCriteria)
                            {
                                case "Source IP":
                                    return ipPacket.SourceAddress.ToString().ToLower().Contains(searchText);
                                case "Destination IP":
                                    return ipPacket.DestinationAddress.ToString().ToLower().Contains(searchText);
                                case "Source Port":
                                    return tcpPacket.SourcePort.ToString().ToLower().Contains(searchText);
                                case "Destination Port":
                                    return tcpPacket.DestinationPort.ToString().ToLower().Contains(searchText);
                            }
                        }
                        else if (ipPacket.PayloadPacket is UdpPacket udpPacket)
                        {
                            switch (searchCriteria)
                            {
                                case "Source IP":
                                    return ipPacket.SourceAddress.ToString().ToLower().Contains(searchText);
                                case "Destination IP":
                                    return ipPacket.DestinationAddress.ToString().ToLower().Contains(searchText);
                                case "Source Port":
                                    return udpPacket.SourcePort.ToString().ToLower().Contains(searchText);
                                case "Destination Port":
                                    return udpPacket.DestinationPort.ToString().ToLower().Contains(searchText);
                            }
                        }
                    }
                }
                return false;
            }).ToList();

            DisplaySearchResults(searchResults);
        }
    }
}