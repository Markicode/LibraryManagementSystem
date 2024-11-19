namespace LibraryEmployeeApplication
{
    partial class EmployeeMainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeMainForm));
            LogoPictureBox = new PictureBox();
            CloseButtonLabel = new Label();
            MenuLabel1 = new Label();
            label1 = new Label();
            MenuLabel2 = new Label();
            MenuLabel3 = new Label();
            MenuLabel4 = new Label();
            MenuLabel5 = new Label();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // LogoPictureBox
            // 
            LogoPictureBox.Image = (Image)resources.GetObject("LogoPictureBox.Image");
            LogoPictureBox.Location = new Point(12, 12);
            LogoPictureBox.Name = "LogoPictureBox";
            LogoPictureBox.Size = new Size(1203, 121);
            LogoPictureBox.TabIndex = 0;
            LogoPictureBox.TabStop = false;
            // 
            // CloseButtonLabel
            // 
            CloseButtonLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CloseButtonLabel.AutoSize = true;
            CloseButtonLabel.Font = new Font("Lato", 24F, FontStyle.Regular, GraphicsUnit.Point);
            CloseButtonLabel.ForeColor = Color.OrangeRed;
            CloseButtonLabel.Location = new Point(1265, 12);
            CloseButtonLabel.Name = "CloseButtonLabel";
            CloseButtonLabel.Size = new Size(38, 39);
            CloseButtonLabel.TabIndex = 1;
            CloseButtonLabel.Text = "X";
            CloseButtonLabel.Click += CloseButtonLabel_Click;
            CloseButtonLabel.MouseEnter += CloseButtonLabel_MouseEnter;
            CloseButtonLabel.MouseLeave += CloseButtonLabel_MouseLeave;
            // 
            // MenuLabel1
            // 
            MenuLabel1.AutoSize = true;
            MenuLabel1.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel1.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel1.Location = new Point(32, 171);
            MenuLabel1.Name = "MenuLabel1";
            MenuLabel1.Size = new Size(62, 25);
            MenuLabel1.TabIndex = 2;
            MenuLabel1.Text = "Login";
            MenuLabel1.Click += MenuLabel1_Click;
            MenuLabel1.MouseEnter += MenuLabel1_MouseEnter;
            MenuLabel1.MouseLeave += MenuLabel1_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(245, 163);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 3;
            // 
            // MenuLabel2
            // 
            MenuLabel2.AutoSize = true;
            MenuLabel2.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel2.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel2.Location = new Point(32, 219);
            MenuLabel2.Name = "MenuLabel2";
            MenuLabel2.Size = new Size(80, 25);
            MenuLabel2.TabIndex = 4;
            MenuLabel2.Text = "Inname";
            MenuLabel2.Click += MenuLabel2_Click;
            MenuLabel2.MouseEnter += MenuLabel2_MouseEnter;
            MenuLabel2.MouseLeave += MenuLabel2_MouseLeave;
            // 
            // MenuLabel3
            // 
            MenuLabel3.AutoSize = true;
            MenuLabel3.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel3.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel3.Location = new Point(32, 264);
            MenuLabel3.Name = "MenuLabel3";
            MenuLabel3.Size = new Size(83, 25);
            MenuLabel3.TabIndex = 5;
            MenuLabel3.Text = "Uitgave";
            MenuLabel3.Click += MenuLabel3_Click;
            MenuLabel3.MouseEnter += MenuLabel3_MouseEnter;
            MenuLabel3.MouseLeave += MenuLabel3_MouseLeave;
            // 
            // MenuLabel4
            // 
            MenuLabel4.AutoSize = true;
            MenuLabel4.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel4.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel4.Location = new Point(32, 309);
            MenuLabel4.Name = "MenuLabel4";
            MenuLabel4.Size = new Size(105, 25);
            MenuLabel4.TabIndex = 6;
            MenuLabel4.Text = "Zoek Item";
            MenuLabel4.Click += MenuLabel4_Click;
            MenuLabel4.MouseEnter += MenuLabel4_MouseEnter;
            MenuLabel4.MouseLeave += MenuLabel4_MouseLeave;
            // 
            // MenuLabel5
            // 
            MenuLabel5.AutoSize = true;
            MenuLabel5.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            MenuLabel5.ForeColor = Color.FromArgb(33, 0, 127);
            MenuLabel5.Location = new Point(32, 352);
            MenuLabel5.Name = "MenuLabel5";
            MenuLabel5.Size = new Size(139, 25);
            MenuLabel5.TabIndex = 7;
            MenuLabel5.Text = "Zoek Persoon";
            MenuLabel5.Click += MenuLabel5_Click;
            MenuLabel5.MouseEnter += MenuLabel5_MouseEnter;
            MenuLabel5.MouseLeave += MenuLabel5_MouseLeave;
            // 
            // EmployeeMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1336, 552);
            Controls.Add(MenuLabel5);
            Controls.Add(MenuLabel4);
            Controls.Add(MenuLabel3);
            Controls.Add(MenuLabel2);
            Controls.Add(label1);
            Controls.Add(MenuLabel1);
            Controls.Add(LogoPictureBox);
            Controls.Add(CloseButtonLabel);
            Name = "EmployeeMainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox LogoPictureBox;
        private Label CloseButtonLabel;
        private Label MenuLabel1;
        private Label label1;
        private Label MenuLabel2;
        private Label MenuLabel3;
        private Label MenuLabel4;
        private Label MenuLabel5;
    }
}
