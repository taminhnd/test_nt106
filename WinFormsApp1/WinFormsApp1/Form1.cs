using System;
using System.Linq;
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
        private ICaptureDevice deviceIB;
        private CaptureDeviceList devices = CaptureDeviceList.Instance;
        private List<Packet> packetList = new List<Packet>();

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



            Task.Run(() => StartPacketCapture());
        }

        private void buttonStopCapture_Click(object sender, EventArgs e)
        {
            deviceIA.Close();
            byte[] data = packetList.ElementAt(packetList.Count - 1).PayloadPacket.PayloadPacket.PayloadData;
            string a = Encoding.UTF8.GetString(data);
            //textBox1.Text = a;
            //deviceIB?.Close();
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

        
    }
}