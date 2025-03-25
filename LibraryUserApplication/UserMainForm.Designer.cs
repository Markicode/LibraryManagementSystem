namespace UserApplication
{
    partial class UserMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        private PictureBox LogoPictureBox;
        private Label MenuLabel1;
        private Label WelcomeLabel;
        private Label MenuLabel2;
        private Label MenuLabel3;
        private Label MenuLabel4;
        private Label MenuLabel5;
        private Label MenuLabel6;
        private Label MenuLabel7;
        private PictureBox SettingsIconBox;
        private PictureBox LogoutIconBox;
        private Label MenuLabel8;
        private PictureBox CloseIconBox;
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMainForm));
            CloseIconBox = new PictureBox();
            MenuLabel8 = new Label();
            LogoutIconBox = new PictureBox();
            SettingsIconBox = new PictureBox();
            MenuLabel7 = new Label();
            MenuLabel6 = new Label();
            MenuLabel5 = new Label();
            MenuLabel4 = new Label();
            MenuLabel3 = new Label();
            MenuLabel2 = new Label();
            WelcomeLabel = new Label();
            MenuLabel1 = new Label();
            LogoPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CloseIconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LogoutIconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SettingsIconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // CloseIconBox
            // 
            CloseIconBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CloseIconBox.Location = new Point(1269, 12);
            CloseIconBox.Name = "CloseIconBox";
            CloseIconBox.Size = new Size(40, 40);
            CloseIconBox.TabIndex = 26;
            CloseIconBox.TabStop = false;
            CloseIconBox.Click += CloseIconBox_Click;
            CloseIconBox.MouseEnter += CloseIconBox_MouseEnter;
            CloseIconBox.MouseLeave += CloseIconBox_MouseLeave;
            // 
            // MenuLabel8
            // 
            MenuLabel8.AutoSize = true;
            MenuLabel8.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel8.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel8.Location = new Point(32, 490);
            MenuLabel8.Name = "MenuLabel8";
            MenuLabel8.Size = new Size(84, 25);
            MenuLabel8.TabIndex = 25;
            MenuLabel8.Text = "Menu 8";
            MenuLabel8.Click += MenuLabel8_Click;
            MenuLabel8.MouseEnter += MenuLabel8_MouseEnter;
            MenuLabel8.MouseLeave += MenuLabel8_MouseLeave;
            // 
            // LogoutIconBox
            // 
            LogoutIconBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LogoutIconBox.Location = new Point(1177, 12);
            LogoutIconBox.Name = "LogoutIconBox";
            LogoutIconBox.Size = new Size(40, 40);
            LogoutIconBox.TabIndex = 24;
            LogoutIconBox.TabStop = false;
            LogoutIconBox.Click += LogoutIconBox_Click;
            LogoutIconBox.MouseEnter += LogoutIconBox_MouseEnter;
            LogoutIconBox.MouseLeave += LogoutIconBox_MouseLeave;
            // 
            // SettingsIconBox
            // 
            SettingsIconBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SettingsIconBox.Location = new Point(1223, 12);
            SettingsIconBox.Name = "SettingsIconBox";
            SettingsIconBox.Size = new Size(40, 40);
            SettingsIconBox.TabIndex = 23;
            SettingsIconBox.TabStop = false;
            SettingsIconBox.Click += SettingsIconBox_Click;
            SettingsIconBox.MouseEnter += SettingsIconBox_MouseEnter;
            SettingsIconBox.MouseLeave += SettingsIconBox_MouseLeave;
            // 
            // MenuLabel7
            // 
            MenuLabel7.AutoSize = true;
            MenuLabel7.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel7.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel7.Location = new Point(32, 445);
            MenuLabel7.Name = "MenuLabel7";
            MenuLabel7.Size = new Size(84, 25);
            MenuLabel7.TabIndex = 22;
            MenuLabel7.Text = "Menu 7";
            MenuLabel7.Click += MenuLabel7_Click;
            MenuLabel7.MouseEnter += MenuLabel7_MouseEnter;
            MenuLabel7.MouseLeave += MenuLabel7_MouseLeave;
            // 
            // MenuLabel6
            // 
            MenuLabel6.AutoSize = true;
            MenuLabel6.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel6.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel6.Location = new Point(32, 400);
            MenuLabel6.Name = "MenuLabel6";
            MenuLabel6.Size = new Size(84, 25);
            MenuLabel6.TabIndex = 21;
            MenuLabel6.Text = "Menu 6";
            MenuLabel6.Click += MenuLabel6_Click;
            MenuLabel6.MouseEnter += MenuLabel6_MouseEnter;
            MenuLabel6.MouseLeave += MenuLabel6_MouseLeave;
            // 
            // MenuLabel5
            // 
            MenuLabel5.AutoSize = true;
            MenuLabel5.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel5.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel5.Location = new Point(32, 355);
            MenuLabel5.Name = "MenuLabel5";
            MenuLabel5.Size = new Size(84, 25);
            MenuLabel5.TabIndex = 20;
            MenuLabel5.Text = "Menu 5";
            MenuLabel5.MouseEnter += MenuLabel5_MouseEnter;
            MenuLabel5.MouseLeave += MenuLabel5_MouseLeave;
            // 
            // MenuLabel4
            // 
            MenuLabel4.AutoSize = true;
            MenuLabel4.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel4.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel4.Location = new Point(32, 310);
            MenuLabel4.Name = "MenuLabel4";
            MenuLabel4.Size = new Size(84, 25);
            MenuLabel4.TabIndex = 19;
            MenuLabel4.Text = "Menu 4";
            MenuLabel4.Click += MenuLabel4_Click;
            MenuLabel4.MouseEnter += MenuLabel4_MouseEnter;
            MenuLabel4.MouseLeave += MenuLabel4_MouseLeave;
            // 
            // MenuLabel3
            // 
            MenuLabel3.AutoSize = true;
            MenuLabel3.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel3.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel3.Location = new Point(32, 265);
            MenuLabel3.Name = "MenuLabel3";
            MenuLabel3.Size = new Size(84, 25);
            MenuLabel3.TabIndex = 18;
            MenuLabel3.Text = "Menu 3";
            MenuLabel3.Click += MenuLabel3_Click;
            MenuLabel3.MouseEnter += MenuLabel3_MouseEnter;
            MenuLabel3.MouseLeave += MenuLabel3_MouseLeave;
            // 
            // MenuLabel2
            // 
            MenuLabel2.AutoSize = true;
            MenuLabel2.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel2.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel2.Location = new Point(32, 220);
            MenuLabel2.Name = "MenuLabel2";
            MenuLabel2.Size = new Size(84, 25);
            MenuLabel2.TabIndex = 17;
            MenuLabel2.Text = "Menu 2";
            MenuLabel2.Click += MenuLabel2_Click;
            MenuLabel2.MouseEnter += MenuLabel2_MouseEnter;
            MenuLabel2.MouseLeave += MenuLabel2_MouseLeave;
            // 
            // WelcomeLabel
            // 
            WelcomeLabel.AutoSize = true;
            WelcomeLabel.Font = new Font("Lato", 14F, FontStyle.Regular, GraphicsUnit.Point);
            WelcomeLabel.Location = new Point(240, 175);
            WelcomeLabel.Name = "WelcomeLabel";
            WelcomeLabel.Size = new Size(89, 23);
            WelcomeLabel.TabIndex = 16;
            WelcomeLabel.Text = "Welcome";
            // 
            // MenuLabel1
            // 
            MenuLabel1.AutoSize = true;
            MenuLabel1.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel1.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel1.Location = new Point(32, 175);
            MenuLabel1.Name = "MenuLabel1";
            MenuLabel1.Size = new Size(84, 25);
            MenuLabel1.TabIndex = 15;
            MenuLabel1.Text = "Menu 1";
            MenuLabel1.Click += MenuLabel1_Click;
            MenuLabel1.MouseEnter += MenuLabel1_MouseEnter;
            MenuLabel1.MouseLeave += MenuLabel1_MouseLeave;
            // 
            // LogoPictureBox
            // 
            LogoPictureBox.Image = (Image)resources.GetObject("LogoPictureBox.Image");
            LogoPictureBox.Location = new Point(12, 12);
            LogoPictureBox.Name = "LogoPictureBox";
            LogoPictureBox.Size = new Size(1176, 121);
            LogoPictureBox.TabIndex = 14;
            LogoPictureBox.TabStop = false;
            // 
            // UserMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1366, 778);
            Controls.Add(CloseIconBox);
            Controls.Add(MenuLabel8);
            Controls.Add(LogoutIconBox);
            Controls.Add(SettingsIconBox);
            Controls.Add(MenuLabel7);
            Controls.Add(MenuLabel6);
            Controls.Add(MenuLabel5);
            Controls.Add(MenuLabel4);
            Controls.Add(MenuLabel3);
            Controls.Add(MenuLabel2);
            Controls.Add(WelcomeLabel);
            Controls.Add(MenuLabel1);
            Controls.Add(LogoPictureBox);
            Name = "UserMainForm";
            Text = "Form1";
            Load += UserMainForm_Load;
            ((System.ComponentModel.ISupportInitialize)CloseIconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)LogoutIconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)SettingsIconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
