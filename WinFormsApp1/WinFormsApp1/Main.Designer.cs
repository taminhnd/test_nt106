namespace WinFormsApp1
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxDeviceIA;
        private System.Windows.Forms.ComboBox comboBoxDeviceIB;
        private System.Windows.Forms.Button buttonStartCapture;
        private System.Windows.Forms.Button buttonStopCapture;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboBoxDeviceIA = new ComboBox();
            comboBoxDeviceIB = new ComboBox();
            buttonStartCapture = new Button();
            buttonStopCapture = new Button();
            listViewPackets = new ListView();
            No_of_packet = new ColumnHeader();
            Source_IP = new ColumnHeader();
            Des_IP = new ColumnHeader();
            Source_Port = new ColumnHeader();
            Des_Port = new ColumnHeader();
            Source_Mac = new ColumnHeader();
            Des_Mac = new ColumnHeader();
            label1 = new Label();
            label2 = new Label();
            Send_packet = new Button();
            Sour_IP_textBox = new TextBox();
            Dest_IP_textBox = new TextBox();
            Sour_Port_textBox = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            Dest_Port_textBox = new TextBox();
            label8 = new Label();
            sentpacket_counts_label = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxDeviceIA
            // 
            comboBoxDeviceIA.FormattingEnabled = true;
            comboBoxDeviceIA.Location = new Point(96, 4);
            comboBoxDeviceIA.Name = "comboBoxDeviceIA";
            comboBoxDeviceIA.Size = new Size(437, 33);
            comboBoxDeviceIA.TabIndex = 0;
            // 
            // comboBoxDeviceIB
            // 
            comboBoxDeviceIB.FormattingEnabled = true;
            comboBoxDeviceIB.Location = new Point(96, 43);
            comboBoxDeviceIB.Name = "comboBoxDeviceIB";
            comboBoxDeviceIB.Size = new Size(437, 33);
            comboBoxDeviceIB.TabIndex = 1;
            // 
            // buttonStartCapture
            // 
            buttonStartCapture.Location = new Point(6, 82);
            buttonStartCapture.Name = "buttonStartCapture";
            buttonStartCapture.Size = new Size(260, 42);
            buttonStartCapture.TabIndex = 2;
            buttonStartCapture.Text = "Start Capture";
            buttonStartCapture.UseVisualStyleBackColor = true;
            buttonStartCapture.Click += buttonStartCapture_Click;
            // 
            // buttonStopCapture
            // 
            buttonStopCapture.Location = new Point(272, 82);
            buttonStopCapture.Name = "buttonStopCapture";
            buttonStopCapture.Size = new Size(260, 42);
            buttonStopCapture.TabIndex = 3;
            buttonStopCapture.Text = "Stop Capture";
            buttonStopCapture.UseVisualStyleBackColor = true;
            buttonStopCapture.Click += buttonStopCapture_Click;
            // 
            // listViewPackets
            // 
            listViewPackets.Alignment = ListViewAlignment.SnapToGrid;
            listViewPackets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            listViewPackets.Columns.AddRange(new ColumnHeader[] { No_of_packet, Source_IP, Des_IP, Source_Port, Des_Port, Source_Mac, Des_Mac });
            listViewPackets.FullRowSelect = true;
            listViewPackets.Location = new Point(5, 137);
            listViewPackets.Name = "listViewPackets";
            listViewPackets.Size = new Size(1318, 703);
            listViewPackets.TabIndex = 6;
            listViewPackets.UseCompatibleStateImageBehavior = false;
            listViewPackets.View = View.Details;
            listViewPackets.MouseDoubleClick += listViewPackets_MouseDoubleClick;
            // 
            // No_of_packet
            // 
            No_of_packet.Text = "#";
            No_of_packet.Width = 70;
            // 
            // Source_IP
            // 
            Source_IP.Text = "Source IP";
            Source_IP.Width = 280;
            // 
            // Des_IP
            // 
            Des_IP.Text = "Destination IP";
            Des_IP.Width = 280;
            // 
            // Source_Port
            // 
            Source_Port.Text = "Source Port";
            Source_Port.Width = 150;
            // 
            // Des_Port
            // 
            Des_Port.Text = "Destination Port";
            Des_Port.Width = 150;
            // 
            // Source_Mac
            // 
            Source_Mac.Text = "Source MAC";
            Source_Mac.Width = 180;
            // 
            // Des_Mac
            // 
            Des_Mac.Text = "Destination MAC";
            Des_Mac.Width = 180;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 7);
            label1.Name = "label1";
            label1.Size = new Size(86, 25);
            label1.TabIndex = 7;
            label1.Text = "Device IA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 46);
            label2.Name = "label2";
            label2.Size = new Size(84, 25);
            label2.TabIndex = 8;
            label2.Text = "Device IB";
            // 
            // Send_packet
            // 
            Send_packet.Location = new Point(1055, 82);
            Send_packet.Name = "Send_packet";
            Send_packet.Size = new Size(260, 42);
            Send_packet.TabIndex = 9;
            Send_packet.Text = "Send Captured Packet";
            Send_packet.UseVisualStyleBackColor = true;
            Send_packet.Click += Send_packet_Click;
            // 
            // Sour_IP_textBox
            // 
            Sour_IP_textBox.Location = new Point(648, 6);
            Sour_IP_textBox.Name = "Sour_IP_textBox";
            Sour_IP_textBox.Size = new Size(261, 31);
            Sour_IP_textBox.TabIndex = 10;
            // 
            // Dest_IP_textBox
            // 
            Dest_IP_textBox.Location = new Point(1055, 6);
            Dest_IP_textBox.Name = "Dest_IP_textBox";
            Dest_IP_textBox.Size = new Size(261, 31);
            Dest_IP_textBox.TabIndex = 11;
            // 
            // Sour_Port_textBox
            // 
            Sour_Port_textBox.Location = new Point(648, 45);
            Sour_Port_textBox.Name = "Sour_Port_textBox";
            Sour_Port_textBox.Size = new Size(261, 31);
            Sour_Port_textBox.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(915, 48);
            label7.Name = "label7";
            label7.Size = new Size(139, 25);
            label7.TabIndex = 18;
            label7.Text = "Destination Port";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(539, 48);
            label6.Name = "label6";
            label6.Size = new Size(103, 25);
            label6.TabIndex = 17;
            label6.Text = "Source Port";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(915, 9);
            label5.Name = "label5";
            label5.Size = new Size(122, 25);
            label5.TabIndex = 16;
            label5.Text = "Destination IP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(539, 9);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 14;
            label3.Text = "Source IP";
            // 
            // Dest_Port_textBox
            // 
            Dest_Port_textBox.Location = new Point(1055, 45);
            Dest_Port_textBox.Name = "Dest_Port_textBox";
            Dest_Port_textBox.Size = new Size(261, 31);
            Dest_Port_textBox.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(665, 86);
            label8.Name = "label8";
            label8.Size = new Size(112, 25);
            label8.TabIndex = 14;
            label8.Text = "Packets sent:";
            // 
            // sentpacket_counts_label
            // 
            sentpacket_counts_label.AutoSize = true;
            sentpacket_counts_label.Location = new Point(853, 86);
            sentpacket_counts_label.Name = "sentpacket_counts_label";
            sentpacket_counts_label.Size = new Size(22, 25);
            sentpacket_counts_label.TabIndex = 15;
            sentpacket_counts_label.Text = "0";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.Controls.Add(Send_packet);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Sour_IP_textBox);
            panel1.Controls.Add(sentpacket_counts_label);
            panel1.Controls.Add(comboBoxDeviceIA);
            panel1.Controls.Add(Sour_Port_textBox);
            panel1.Controls.Add(comboBoxDeviceIB);
            panel1.Controls.Add(buttonStartCapture);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(buttonStopCapture);
            panel1.Controls.Add(Dest_Port_textBox);
            panel1.Controls.Add(Dest_IP_textBox);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(7, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1318, 127);
            panel1.TabIndex = 19;
            // 
            // Main
            // 
            ClientSize = new Size(1332, 852);
            Controls.Add(panel1);
            Controls.Add(listViewPackets);
            Name = "Main";
            Text = "Network Tamper";
            Load += Form1_Load;
            Resize += Main_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private ListView listViewPackets;
        private ColumnHeader No_of_packet;
        private ColumnHeader Source_IP;
        private ColumnHeader Des_IP;
        private ColumnHeader Source_Port;
        private ColumnHeader Des_Port;
        private ColumnHeader Source_Mac;
        private ColumnHeader Des_Mac;
        private Label label1;
        private Label label2;
        private Button Send_packet;
        private TextBox Sour_IP_textBox;
        private TextBox Dest_IP_textBox;
        private TextBox Sour_Port_textBox;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private TextBox Dest_Port_textBox;
        private Label label8;
        private Label sentpacket_counts_label;
        private Panel panel1;
    }
}
