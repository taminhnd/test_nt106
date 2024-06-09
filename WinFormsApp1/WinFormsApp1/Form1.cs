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
    public partial class Form1 : Form
    {
        private ICaptureDevice deviceIA;
        private ILiveDevice deviceIB;
        private CaptureDeviceList devices = CaptureDeviceList.Instance;
        private List<Packet> packetList = new List<Packet>();
        bool isCapturing = false;

        public Form1()
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

                                    if (listBoxPackets.InvokeRequired)
                                    {
                                        listBoxPackets.Invoke(new MethodInvoker(delegate
                                        {
                                            /*listBoxPackets.Items.Add($"Packet: Source IP: {sourceIp}, Source Port: {sourcePort}, Destination IP: {destinationIp}, Destination Port: {destinationPort}");
                                            listBoxPackets.TopIndex = listBoxPackets.Items.Count - 1;*/
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
                                        /*listBoxPackets.Items.Add($"Packet: Source IP: {sourceIp}, Source Port: {sourcePort}, Destination IP: {destinationIp}, Destination Port: {destinationPort}");
                                        listBoxPackets.TopIndex = listBoxPackets.Items.Count - 1;*/
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
            if(!IPAddress.TryParse(destIP, out IPAddress _))
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
                // Check if the network interface matches the description of deviceIB
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

            if(!CorrectInfoFormat(Sour_IP_textBox.Text, Dest_IP_textBox.Text, Sour_Port_textBox.Text, Dest_Port_textBox.Text))
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

            Task.Run(() => StartSendingPacket(sentsourceIP,sentdestinationIP,sentsourcePort,sentdestinationPort));
            
        }

        private void StartSendingPacket(string sentsourceIP, string sentdestinationIP, int sentsourcePort, int sentdestinationPort)
        {
            try
            {
                MessageBox.Show("Opening device IB");
                deviceIB.Open();
                deviceIA.Open();

                if (packetList.Count == 0)
                {
                    Console.WriteLine("Packet list is empty. Nothing to send.");
                    return;
                }

                foreach (var packet in packetList)
                {
                    if (packet is EthernetPacket ethernetPacket)
                    {
                        if (ethernetPacket.PayloadPacket is IPPacket ipPacket)
                        {
                            // Modify the source and destination IP addresses
                            ipPacket.SourceAddress = IPAddress.Parse(sentsourceIP);
                            ipPacket.DestinationAddress = IPAddress.Parse(sentdestinationIP);

                            if (ipPacket.PayloadPacket is TcpPacket tcpPacket)
                            {
                                // Modify the source and destination ports
                                tcpPacket.SourcePort = (ushort)sentsourcePort;
                                tcpPacket.DestinationPort = (ushort)sentdestinationPort;

                                // Recalculate the checksum
                                tcpPacket.UpdateCalculatedValues();
                                ipPacket.UpdateCalculatedValues();
                            }
                            else if (ipPacket.PayloadPacket is UdpPacket udpPacket)
                            {
                                // Modify the source and destination ports
                                udpPacket.SourcePort = (ushort)sentsourcePort;
                                udpPacket.DestinationPort = (ushort)sentdestinationPort;

                                // Recalculate the checksum
                                udpPacket.UpdateCalculatedValues();
                                ipPacket.UpdateCalculatedValues();
                            }
                        }
                        
                        // Send the modified packet
                        deviceIB.SendPacket(ethernetPacket);
                    }
                    else
                    {
                        MessageBox.Show("Packet is not an EthernetPacket.");
                    }
                }

                deviceIA.Close();
                deviceIB.Close();
                MessageBox.Show("Packets sent successfully.");

            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error sending packets: {ex.Message}");
            }
        }
    }
}