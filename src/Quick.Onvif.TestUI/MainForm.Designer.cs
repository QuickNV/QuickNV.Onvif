namespace Quick.Onvif.TestUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tcMain = new TabControl();
            tabPage1 = new TabPage();
            odcDevice = new ObjectDisplayControl();
            tabPage2 = new TabPage();
            odcNetwork = new ObjectDisplayControl();
            tcMain.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tabPage1);
            tcMain.Controls.Add(tabPage2);
            tcMain.Dock = DockStyle.Fill;
            tcMain.Location = new Point(0, 0);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1011, 626);
            tcMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(odcDevice);
            tabPage1.Location = new Point(4, 33);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1003, 589);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Device";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // odcDevice
            // 
            odcDevice.Dock = DockStyle.Fill;
            odcDevice.Location = new Point(3, 3);
            odcDevice.Name = "odcDevice";
            odcDevice.RefreshAsyncFunc = null;
            odcDevice.Size = new Size(997, 583);
            odcDevice.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(odcNetwork);
            tabPage2.Location = new Point(4, 33);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1003, 589);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Network";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // odcNetwork
            // 
            odcNetwork.Dock = DockStyle.Fill;
            odcNetwork.Location = new Point(3, 3);
            odcNetwork.Name = "odcNetwork";
            odcNetwork.RefreshAsyncFunc = null;
            odcNetwork.Size = new Size(997, 583);
            odcNetwork.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 626);
            Controls.Add(tcMain);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            tcMain.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcMain;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ObjectDisplayControl odcDevice;
        private ObjectDisplayControl odcNetwork;
    }
}