namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxDeviceIA;
        private System.Windows.Forms.ComboBox comboBoxDeviceIB;
        private System.Windows.Forms.Button buttonStartCapture;
        private System.Windows.Forms.Button buttonStopCapture;
        private System.Windows.Forms.ListBox listBoxPackets;

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
            listBoxPackets = new ListBox();
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
            panel1 = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            Dest_Port_textBox = new TextBox();
            label8 = new Label();
            sentpacket_counts_label = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxDeviceIA
            // 
            comboBoxDeviceIA.FormattingEnabled = true;
            comboBoxDeviceIA.Location = new Point(121, 12);
            comboBoxDeviceIA.Name = "comboBoxDeviceIA";
            comboBoxDeviceIA.Size = new Size(839, 28);
            comboBoxDeviceIA.TabIndex = 0;
            // 
            // comboBoxDeviceIB
            // 
            comboBoxDeviceIB.FormattingEnabled = true;
            comboBoxDeviceIB.Location = new Point(121, 51);
            comboBoxDeviceIB.Name = "comboBoxDeviceIB";
            comboBoxDeviceIB.Size = new Size(839, 28);
            comboBoxDeviceIB.TabIndex = 1;
            // 
            // buttonStartCapture
            // 
            buttonStartCapture.Location = new Point(12, 90);
            buttonStartCapture.Name = "buttonStartCapture";
            buttonStartCapture.Size = new Size(458, 42);
            buttonStartCapture.TabIndex = 2;
            buttonStartCapture.Text = "Start Capture";
            buttonStartCapture.UseVisualStyleBackColor = true;
            buttonStartCapture.Click += buttonStartCapture_Click;
            // 
            // buttonStopCapture
            // 
            buttonStopCapture.Location = new Point(476, 90);
            buttonStopCapture.Name = "buttonStopCapture";
            buttonStopCapture.Size = new Size(484, 42);
            buttonStopCapture.TabIndex = 3;
            buttonStopCapture.Text = "Stop Capture";
            buttonStopCapture.UseVisualStyleBackColor = true;
            buttonStopCapture.Click += buttonStopCapture_Click;
            // 
            // listBoxPackets
            // 
            listBoxPackets.AllowDrop = true;
            listBoxPackets.FormattingEnabled = true;
            listBoxPackets.Location = new Point(12, 147);
            listBoxPackets.Name = "listBoxPackets";
            listBoxPackets.Size = new Size(889, 224);
            listBoxPackets.TabIndex = 4;
            // 
            // listViewPackets
            // 
            listViewPackets.Alignment = ListViewAlignment.SnapToGrid;
            listViewPackets.Columns.AddRange(new ColumnHeader[] { No_of_packet, Source_IP, Des_IP, Source_Port, Des_Port, Source_Mac, Des_Mac });
            listViewPackets.FullRowSelect = true;
            listViewPackets.Location = new Point(7, 138);
            listViewPackets.Name = "listViewPackets";
            listViewPackets.Size = new Size(964, 395);
            listViewPackets.TabIndex = 6;
            listViewPackets.UseCompatibleStateImageBehavior = false;
            listViewPackets.View = View.Details;
            // 
            // No_of_packet
            // 
            No_of_packet.Text = "#";
            No_of_packet.Width = 50;
            // 
            // Source_IP
            // 
            Source_IP.Text = "Source IP";
            Source_IP.Width = 150;
            // 
            // Des_IP
            // 
            Des_IP.Text = "Destination IP";
            Des_IP.Width = 150;
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
            Source_Mac.Text = "Source_Mac";
            Source_Mac.Width = 150;
            // 
            // Des_Mac
            // 
            Des_Mac.Text = "Destination Mac";
            Des_Mac.Width = 150;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 7;
            label1.Text = "Device IA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 8;
            label2.Text = "Device IB";
            // 
            // Send_packet
            // 
            Send_packet.Location = new Point(1249, 4);
            Send_packet.Name = "Send_packet";
            Send_packet.Size = new Size(180, 128);
            Send_packet.TabIndex = 9;
            Send_packet.Text = "Send captured packet";
            Send_packet.UseVisualStyleBackColor = true;
            Send_packet.Click += Send_packet_Click;
            // 
            // Sour_IP_textBox
            // 
            Sour_IP_textBox.Location = new Point(191, 15);
            Sour_IP_textBox.Name = "Sour_IP_textBox";
            Sour_IP_textBox.Size = new Size(261, 27);
            Sour_IP_textBox.TabIndex = 10;
            // 
            // Dest_IP_textBox
            // 
            Dest_IP_textBox.Location = new Point(191, 81);
            Dest_IP_textBox.Name = "Dest_IP_textBox";
            Dest_IP_textBox.Size = new Size(261, 27);
            Dest_IP_textBox.TabIndex = 11;
            // 
            // Sour_Port_textBox
            // 
            Sour_Port_textBox.Location = new Point(191, 48);
            Sour_Port_textBox.Name = "Sour_Port_textBox";
            Sour_Port_textBox.Size = new Size(261, 27);
            Sour_Port_textBox.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(Dest_Port_textBox);
            panel1.Controls.Add(Sour_IP_textBox);
            panel1.Controls.Add(Dest_IP_textBox);
            panel1.Controls.Add(Sour_Port_textBox);
            panel1.Location = new Point(977, 138);
            panel1.Name = "panel1";
            panel1.Size = new Size(455, 179);
            panel1.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 114);
            label7.Name = "label7";
            label7.Size = new Size(115, 20);
            label7.TabIndex = 18;
            label7.Text = "Destination Port";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 48);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 17;
            label6.Text = "Source Port";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 81);
            label5.Name = "label5";
            label5.Size = new Size(101, 20);
            label5.TabIndex = 16;
            label5.Text = "Destination IP";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 33);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 15);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 14;
            label3.Text = "Source IP";
            // 
            // Dest_Port_textBox
            // 
            Dest_Port_textBox.Location = new Point(191, 114);
            Dest_Port_textBox.Name = "Dest_Port_textBox";
            Dest_Port_textBox.Size = new Size(261, 27);
            Dest_Port_textBox.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(980, 320);
            label8.Name = "label8";
            label8.Size = new Size(91, 20);
            label8.TabIndex = 14;
            label8.Text = "Packets sent:";
            // 
            // sentpacket_counts_label
            // 
            sentpacket_counts_label.AutoSize = true;
            sentpacket_counts_label.Location = new Point(1168, 320);
            sentpacket_counts_label.Name = "sentpacket_counts_label";
            sentpacket_counts_label.Size = new Size(17, 20);
            sentpacket_counts_label.TabIndex = 15;
            sentpacket_counts_label.Text = "0";
            // 
            // Form1
            // 
            ClientSize = new Size(1433, 545);
            Controls.Add(sentpacket_counts_label);
            Controls.Add(label8);
            Controls.Add(panel1);
            Controls.Add(Send_packet);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listViewPackets);
            Controls.Add(comboBoxDeviceIA);
            Controls.Add(comboBoxDeviceIB);
            Controls.Add(buttonStartCapture);
            Controls.Add(listBoxPackets);
            Controls.Add(buttonStopCapture);
            Name = "Form1";
            Text = "Network Tamper";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Panel panel1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox Dest_Port_textBox;
        private Label label8;
        private Label sentpacket_counts_label;
    }
}
