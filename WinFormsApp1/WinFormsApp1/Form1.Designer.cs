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
            SuspendLayout();
            // 
            // comboBoxDeviceIA
            // 
            comboBoxDeviceIA.FormattingEnabled = true;
            comboBoxDeviceIA.Location = new Point(12, 12);
            comboBoxDeviceIA.Name = "comboBoxDeviceIA";
            comboBoxDeviceIA.Size = new Size(889, 33);
            comboBoxDeviceIA.TabIndex = 0;
            // 
            // comboBoxDeviceIB
            // 
            comboBoxDeviceIB.FormattingEnabled = true;
            comboBoxDeviceIB.Location = new Point(12, 46);
            comboBoxDeviceIB.Name = "comboBoxDeviceIB";
            comboBoxDeviceIB.Size = new Size(889, 33);
            comboBoxDeviceIB.TabIndex = 1;
            // 
            // buttonStartCapture
            // 
            buttonStartCapture.Location = new Point(12, 80);
            buttonStartCapture.Name = "buttonStartCapture";
            buttonStartCapture.Size = new Size(430, 42);
            buttonStartCapture.TabIndex = 2;
            buttonStartCapture.Text = "Start Capture";
            buttonStartCapture.UseVisualStyleBackColor = true;
            buttonStartCapture.Click += buttonStartCapture_Click;
            // 
            // buttonStopCapture
            // 
            buttonStopCapture.Location = new Point(448, 80);
            buttonStopCapture.Name = "buttonStopCapture";
            buttonStopCapture.Size = new Size(453, 42);
            buttonStopCapture.TabIndex = 3;
            buttonStopCapture.Text = "Stop Capture";
            buttonStopCapture.UseVisualStyleBackColor = true;
            buttonStopCapture.Click += buttonStopCapture_Click;
            // 
            // listBoxPackets
            // 
            listBoxPackets.AllowDrop = true;
            listBoxPackets.FormattingEnabled = true;
            listBoxPackets.ItemHeight = 25;
            listBoxPackets.Location = new Point(12, 128);
            listBoxPackets.Name = "listBoxPackets";
            listBoxPackets.Size = new Size(889, 229);
            listBoxPackets.TabIndex = 4;
            // 
            // listViewPackets
            // 
            listViewPackets.Alignment = ListViewAlignment.SnapToGrid;
            listViewPackets.Columns.AddRange(new ColumnHeader[] { No_of_packet, Source_IP, Des_IP, Source_Port, Des_Port, Source_Mac, Des_Mac });
            listViewPackets.FullRowSelect = true;
            listViewPackets.Location = new Point(12, 128);
            listViewPackets.Name = "listViewPackets";
            listViewPackets.Size = new Size(954, 229);
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
            // Form1
            // 
            ClientSize = new Size(972, 367);
            Controls.Add(listViewPackets);
            Controls.Add(comboBoxDeviceIA);
            Controls.Add(comboBoxDeviceIB);
            Controls.Add(buttonStartCapture);
            Controls.Add(listBoxPackets);
            Controls.Add(buttonStopCapture);
            Name = "Form1";
            Text = "Network Tamper";
            Load += Form1_Load;
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
    }
}
