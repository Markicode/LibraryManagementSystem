namespace EmployeeApplication
{
    partial class EmployeeServerConnectForm
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
            StatusLabel = new Label();
            ConnectButton = new Button();
            CloseButton = new Button();
            IPTextbox = new TextBox();
            PortTextbox = new TextBox();
            IPLabel = new Label();
            PortLabel = new Label();
            SuspendLayout();
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(214, 86);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(229, 15);
            StatusLabel.TabIndex = 0;
            StatusLabel.Text = "Click connect button to connect to server.";
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(172, 154);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(75, 23);
            ConnectButton.TabIndex = 1;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(389, 157);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 2;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // IPTextbox
            // 
            IPTextbox.Location = new Point(103, 332);
            IPTextbox.Name = "IPTextbox";
            IPTextbox.Size = new Size(193, 23);
            IPTextbox.TabIndex = 3;
            IPTextbox.Text = "127.0.0.1";
            // 
            // PortTextbox
            // 
            PortTextbox.Location = new Point(103, 371);
            PortTextbox.Name = "PortTextbox";
            PortTextbox.Size = new Size(100, 23);
            PortTextbox.TabIndex = 4;
            PortTextbox.Text = "8086";
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Location = new Point(12, 335);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(55, 15);
            IPLabel.TabIndex = 5;
            IPLabel.Text = "IP Adress";
            // 
            // PortLabel
            // 
            PortLabel.AutoSize = true;
            PortLabel.Location = new Point(12, 374);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(29, 15);
            PortLabel.TabIndex = 6;
            PortLabel.Text = "Port";
            // 
            // EmployeeServerConnectForm
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
            Name = "EmployeeServerConnectForm";
            Text = "EmployeeServerConnectForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label StatusLabel;
        private Button ConnectButton;
        private Button CloseButton;
        private TextBox IPTextbox;
        private TextBox PortTextbox;
        private Label IPLabel;
        private Label PortLabel;
    }
}