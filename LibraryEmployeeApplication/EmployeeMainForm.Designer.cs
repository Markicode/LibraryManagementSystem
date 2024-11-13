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
            MenuLabel1.Location = new Point(12, 154);
            MenuLabel1.Name = "MenuLabel1";
            MenuLabel1.Size = new Size(62, 25);
            MenuLabel1.TabIndex = 2;
            MenuLabel1.Text = "Login";
            MenuLabel1.Click += MenuLabel1_Click;
            MenuLabel1.MouseEnter += MenuLabel1_MouseEnter;
            MenuLabel1.MouseLeave += MenuLabel1_MouseLeave;
            // 
            // EmployeeMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1336, 552);
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
    }
}
