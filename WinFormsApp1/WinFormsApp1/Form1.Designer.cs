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
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // comboBoxDeviceIA
            // 
            comboBoxDeviceIA.FormattingEnabled = true;
            comboBoxDeviceIA.Location = new Point(12, 12);
            comboBoxDeviceIA.Name = "comboBoxDeviceIA";
            comboBoxDeviceIA.Size = new Size(889, 28);
            comboBoxDeviceIA.TabIndex = 0;
            // 
            // comboBoxDeviceIB
            // 
            comboBoxDeviceIB.FormattingEnabled = true;
            comboBoxDeviceIB.Location = new Point(12, 46);
            comboBoxDeviceIB.Name = "comboBoxDeviceIB";
            comboBoxDeviceIB.Size = new Size(889, 28);
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
            listBoxPackets.Location = new Point(12, 128);
            listBoxPackets.Name = "listBoxPackets";
            listBoxPackets.Size = new Size(889, 244);
            listBoxPackets.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 378);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1295, 170);
            textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            ClientSize = new Size(1319, 560);
            Controls.Add(textBox1);
            Controls.Add(comboBoxDeviceIA);
            Controls.Add(comboBoxDeviceIB);
            Controls.Add(buttonStartCapture);
            Controls.Add(listBoxPackets);
            Controls.Add(buttonStopCapture);
            Name = "Form1";
            Text = "Network Tamper";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox textBox1;
    }
}
