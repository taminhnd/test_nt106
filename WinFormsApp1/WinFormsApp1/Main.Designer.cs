namespace WinFormsApp1
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

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
            listViewPackets = new ListView();
            No_of_packet = new ColumnHeader();
            Source_IP = new ColumnHeader();
            Des_IP = new ColumnHeader();
            Source_Port = new ColumnHeader();
            Des_Port = new ColumnHeader();
            Source_Mac = new ColumnHeader();
            Des_Mac = new ColumnHeader();
            label8 = new Label();
            label6 = new Label();
            Dest_IP_textBox = new TextBox();
            Dest_Port_textBox = new TextBox();
            buttonStopCapture = new Button();
            label3 = new Label();
            label5 = new Label();
            buttonStartCapture = new Button();
            comboBoxDeviceIB = new ComboBox();
            Sour_Port_textBox = new TextBox();
            comboBoxDeviceIA = new ComboBox();
            sentpacket_counts_label = new Label();
            Sour_IP_textBox = new TextBox();
            label1 = new Label();
            label7 = new Label();
            label2 = new Label();
            Send_packet = new Button();
            btnLoad = new Button();
            btnSave = new Button();
            panel1 = new Panel();
            btnSearch = new Button();
            comboBoxSearch = new ComboBox();
            textBoxSearch = new TextBox();
            label4 = new Label();
            btnDelete = new Button();
            btnExport = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // listViewPackets
            // 
            listViewPackets.Alignment = ListViewAlignment.SnapToGrid;
            listViewPackets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            listViewPackets.BackColor = SystemColors.GradientInactiveCaption;
            listViewPackets.Columns.AddRange(new ColumnHeader[] { No_of_packet, Source_IP, Des_IP, Source_Port, Des_Port, Source_Mac, Des_Mac });
            listViewPackets.Font = new Font("Segoe UI", 12F);
            listViewPackets.ForeColor = SystemColors.WindowText;
            listViewPackets.FullRowSelect = true;
            listViewPackets.Location = new Point(12, 256);
            listViewPackets.Name = "listViewPackets";
            listViewPackets.Size = new Size(1567, 751);
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
            Source_IP.Width = 315;
            // 
            // Des_IP
            // 
            Des_IP.Text = "Destination IP";
            Des_IP.Width = 315;
            // 
            // Source_Port
            // 
            Source_Port.Text = "Source Port";
            Source_Port.Width = 210;
            // 
            // Des_Port
            // 
            Des_Port.Text = "Destination Port";
            Des_Port.Width = 210;
            // 
            // Source_Mac
            // 
            Source_Mac.Text = "Source MAC";
            Source_Mac.Width = 210;
            // 
            // Des_Mac
            // 
            Des_Mac.Text = "Destination MAC";
            Des_Mac.Width = 210;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(789, 106);
            label8.Name = "label8";
            label8.Size = new Size(230, 28);
            label8.TabIndex = 14;
            label8.Text = "Suscessfully packets sent:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(704, 59);
            label6.Name = "label6";
            label6.Size = new Size(113, 28);
            label6.TabIndex = 17;
            label6.Text = "Source Port";
            // 
            // Dest_IP_textBox
            // 
            Dest_IP_textBox.BackColor = SystemColors.Menu;
            Dest_IP_textBox.Location = new Point(1304, 9);
            Dest_IP_textBox.Name = "Dest_IP_textBox";
            Dest_IP_textBox.Size = new Size(261, 34);
            Dest_IP_textBox.TabIndex = 11;
            // 
            // Dest_Port_textBox
            // 
            Dest_Port_textBox.BackColor = SystemColors.Menu;
            Dest_Port_textBox.Location = new Point(1304, 54);
            Dest_Port_textBox.Name = "Dest_Port_textBox";
            Dest_Port_textBox.Size = new Size(261, 34);
            Dest_Port_textBox.TabIndex = 13;
            // 
            // buttonStopCapture
            // 
            buttonStopCapture.BackColor = SystemColors.ButtonHighlight;
            buttonStopCapture.Location = new Point(357, 101);
            buttonStopCapture.Name = "buttonStopCapture";
            buttonStopCapture.Size = new Size(341, 42);
            buttonStopCapture.TabIndex = 3;
            buttonStopCapture.Text = "Stop Capture";
            buttonStopCapture.UseVisualStyleBackColor = false;
            buttonStopCapture.Click += buttonStopCapture_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(704, 12);
            label3.Name = "label3";
            label3.Size = new Size(93, 28);
            label3.TabIndex = 14;
            label3.Text = "Source IP";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1113, 12);
            label5.Name = "label5";
            label5.Size = new Size(133, 28);
            label5.TabIndex = 16;
            label5.Text = "Destination IP";
            // 
            // buttonStartCapture
            // 
            buttonStartCapture.BackColor = SystemColors.ButtonHighlight;
            buttonStartCapture.Location = new Point(10, 101);
            buttonStartCapture.Name = "buttonStartCapture";
            buttonStartCapture.Size = new Size(341, 42);
            buttonStartCapture.TabIndex = 2;
            buttonStartCapture.Text = "Start Capture";
            buttonStartCapture.UseVisualStyleBackColor = false;
            buttonStartCapture.Click += buttonStartCapture_Click;
            // 
            // comboBoxDeviceIB
            // 
            comboBoxDeviceIB.BackColor = SystemColors.Menu;
            comboBoxDeviceIB.FormattingEnabled = true;
            comboBoxDeviceIB.Location = new Point(125, 51);
            comboBoxDeviceIB.Name = "comboBoxDeviceIB";
            comboBoxDeviceIB.Size = new Size(573, 36);
            comboBoxDeviceIB.TabIndex = 1;
            // 
            // Sour_Port_textBox
            // 
            Sour_Port_textBox.BackColor = SystemColors.Menu;
            Sour_Port_textBox.Location = new Point(846, 54);
            Sour_Port_textBox.Name = "Sour_Port_textBox";
            Sour_Port_textBox.Size = new Size(261, 34);
            Sour_Port_textBox.TabIndex = 12;
            // 
            // comboBoxDeviceIA
            // 
            comboBoxDeviceIA.BackColor = SystemColors.Menu;
            comboBoxDeviceIA.FormattingEnabled = true;
            comboBoxDeviceIA.Location = new Point(125, 4);
            comboBoxDeviceIA.Name = "comboBoxDeviceIA";
            comboBoxDeviceIA.Size = new Size(573, 36);
            comboBoxDeviceIA.TabIndex = 0;
            // 
            // sentpacket_counts_label
            // 
            sentpacket_counts_label.AutoSize = true;
            sentpacket_counts_label.Location = new Point(1047, 106);
            sentpacket_counts_label.Name = "sentpacket_counts_label";
            sentpacket_counts_label.Size = new Size(23, 28);
            sentpacket_counts_label.TabIndex = 15;
            sentpacket_counts_label.Text = "0";
            // 
            // Sour_IP_textBox
            // 
            Sour_IP_textBox.BackColor = SystemColors.Menu;
            Sour_IP_textBox.Location = new Point(846, 9);
            Sour_IP_textBox.Name = "Sour_IP_textBox";
            Sour_IP_textBox.Size = new Size(261, 34);
            Sour_IP_textBox.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 7);
            label1.Name = "label1";
            label1.Size = new Size(93, 28);
            label1.TabIndex = 7;
            label1.Text = "Device IA";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1113, 57);
            label7.Name = "label7";
            label7.Size = new Size(153, 28);
            label7.TabIndex = 18;
            label7.Text = "Destination Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 54);
            label2.Name = "label2";
            label2.Size = new Size(91, 28);
            label2.TabIndex = 8;
            label2.Text = "Device IB";
            // 
            // Send_packet
            // 
            Send_packet.BackColor = SystemColors.ButtonHighlight;
            Send_packet.Location = new Point(1304, 101);
            Send_packet.Name = "Send_packet";
            Send_packet.Size = new Size(260, 42);
            Send_packet.TabIndex = 9;
            Send_packet.Text = "Send Captured Packet";
            Send_packet.UseVisualStyleBackColor = false;
            Send_packet.Click += Send_packet_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = SystemColors.ButtonHighlight;
            btnLoad.Location = new Point(357, 149);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(341, 42);
            btnLoad.TabIndex = 20;
            btnLoad.Text = "Load Packets";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ButtonHighlight;
            btnSave.Location = new Point(10, 149);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(341, 42);
            btnSave.TabIndex = 19;
            btnSave.Text = "Save Packets";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(comboBoxSearch);
            panel1.Controls.Add(textBoxSearch);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnExport);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnLoad);
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
            panel1.Font = new Font("Segoe UI", 12F);
            panel1.Location = new Point(12, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1567, 246);
            panel1.TabIndex = 19;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ButtonHighlight;
            btnSearch.Location = new Point(1304, 196);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(260, 42);
            btnSearch.TabIndex = 26;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // comboBoxSearch
            // 
            comboBoxSearch.FormattingEnabled = true;
            comboBoxSearch.Items.AddRange(new object[] { "Source IP", "Destination IP", "Source Port", "Destination Port" });
            comboBoxSearch.Location = new Point(800, 151);
            comboBoxSearch.Name = "comboBoxSearch";
            comboBoxSearch.Size = new Size(232, 36);
            comboBoxSearch.TabIndex = 25;
            // 
            // textBoxSearch
            // 
            textBoxSearch.BackColor = SystemColors.Menu;
            textBoxSearch.Location = new Point(1038, 151);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(526, 34);
            textBoxSearch.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(704, 154);
            label4.Name = "label4";
            label4.Size = new Size(74, 28);
            label4.TabIndex = 23;
            label4.Text = "Search:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.ButtonHighlight;
            btnDelete.Location = new Point(10, 197);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(341, 42);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = SystemColors.ButtonHighlight;
            btnExport.Location = new Point(357, 197);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(341, 42);
            btnExport.TabIndex = 22;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // Main
            // 
            BackColor = SystemColors.MenuBar;
            ClientSize = new Size(1591, 1019);
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
        private Label label8;
        private Label label6;
        private TextBox Dest_IP_textBox;
        private TextBox Dest_Port_textBox;
        private Button buttonStopCapture;
        private Label label3;
        private Label label5;
        private Button buttonStartCapture;
        private ComboBox comboBoxDeviceIB;
        private TextBox Sour_Port_textBox;
        private ComboBox comboBoxDeviceIA;
        private Label sentpacket_counts_label;
        private TextBox Sour_IP_textBox;
        private Label label1;
        private Label label7;
        private Label label2;
        private Button Send_packet;
        private Button btnLoad;
        private Button btnSave;
        private Panel panel1;
        private Button btnDelete;
        private Button btnExport;
        private TextBox textBoxSearch;
        private Label label4;
        private ComboBox comboBoxSearch;
        private Button btnSearch;
    }
}
