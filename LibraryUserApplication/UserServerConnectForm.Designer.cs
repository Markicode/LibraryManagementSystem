namespace UserApplication
{
    partial class UserServerConnectForm
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
            PortLabel = new Label();
            IPLabel = new Label();
            PortTextbox = new TextBox();
            IPTextbox = new TextBox();
            CloseButton = new Button();
            ConnectButton = new Button();
            StatusLabel = new Label();
            SuspendLayout();
            // 
            // PortLabel
            // 
            PortLabel.AutoSize = true;
            PortLabel.Location = new Point(59, 334);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(29, 15);
            PortLabel.TabIndex = 13;
            PortLabel.Text = "Port";
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Location = new Point(59, 295);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(55, 15);
            IPLabel.TabIndex = 12;
            IPLabel.Text = "IP Adress";
            // 
            // PortTextbox
            // 
            PortTextbox.Location = new Point(150, 331);
            PortTextbox.Name = "PortTextbox";
            PortTextbox.Size = new Size(100, 23);
            PortTextbox.TabIndex = 11;
            PortTextbox.Text = "8086";
            // 
            // IPTextbox
            // 
            IPTextbox.Location = new Point(150, 292);
            IPTextbox.Name = "IPTextbox";
            IPTextbox.Size = new Size(193, 23);
            IPTextbox.TabIndex = 10;
            IPTextbox.Text = "127.0.0.1";
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(436, 117);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 9;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(219, 114);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(75, 23);
            ConnectButton.TabIndex = 8;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(261, 46);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(229, 15);
            StatusLabel.TabIndex = 7;
            StatusLabel.Text = "Click connect button to connect to server.";
            // 
            // UserServerConnectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PortLabel);
            Controls.Add(IPLabel);
            Controls.Add(PortTextbox);
            Controls.Add(IPTextbox);
            Controls.Add(CloseButton);
            Controls.Add(ConnectButton);
            Controls.Add(StatusLabel);
            Name = "UserServerConnectForm";
            Text = "UserServerConnectForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PortLabel;
        private Label IPLabel;
        private TextBox PortTextbox;
        private TextBox IPTextbox;
        private Button CloseButton;
        private Button ConnectButton;
        private Label StatusLabel;
    }
}