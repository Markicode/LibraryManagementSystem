namespace EmployeeApplication
{
    partial class EmployeeSingleEmployeeForm
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
            TitleLabel = new Label();
            FirstNameLabel = new Label();
            LastNameLabel = new Label();
            BirthDateTimePicker = new DateTimePicker();
            BirthDateLabel = new Label();
            FirstNameTextbox = new TextBox();
            LastNameTextbox = new TextBox();
            RoleTextbox = new TextBox();
            RoleLabel = new Label();
            DomainAccountTextbox = new TextBox();
            DomainNameLabel = new Label();
            EmailLabel = new Label();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Lato", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            TitleLabel.Location = new Point(12, 9);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(133, 23);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Add Employee";
            // 
            // FirstNameLabel
            // 
            FirstNameLabel.AutoSize = true;
            FirstNameLabel.Font = new Font("Lato", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            FirstNameLabel.Location = new Point(12, 58);
            FirstNameLabel.Name = "FirstNameLabel";
            FirstNameLabel.Size = new Size(73, 16);
            FirstNameLabel.TabIndex = 1;
            FirstNameLabel.Text = "First Name:";
            // 
            // LastNameLabel
            // 
            LastNameLabel.AutoSize = true;
            LastNameLabel.Font = new Font("Lato", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            LastNameLabel.Location = new Point(12, 95);
            LastNameLabel.Name = "LastNameLabel";
            LastNameLabel.Size = new Size(71, 16);
            LastNameLabel.TabIndex = 2;
            LastNameLabel.Text = "Last Name:";
            // 
            // BirthDateTimePicker
            // 
            BirthDateTimePicker.Font = new Font("Lato", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            BirthDateTimePicker.Location = new Point(127, 127);
            BirthDateTimePicker.Name = "BirthDateTimePicker";
            BirthDateTimePicker.Size = new Size(200, 23);
            BirthDateTimePicker.TabIndex = 3;
            // 
            // BirthDateLabel
            // 
            BirthDateLabel.AutoSize = true;
            BirthDateLabel.Font = new Font("Lato", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            BirthDateLabel.Location = new Point(12, 133);
            BirthDateLabel.Name = "BirthDateLabel";
            BirthDateLabel.Size = new Size(69, 16);
            BirthDateLabel.TabIndex = 4;
            BirthDateLabel.Text = "Birth Date:";
            // 
            // FirstNameTextbox
            // 
            FirstNameTextbox.BorderStyle = BorderStyle.FixedSingle;
            FirstNameTextbox.Font = new Font("Lato", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            FirstNameTextbox.Location = new Point(127, 55);
            FirstNameTextbox.Name = "FirstNameTextbox";
            FirstNameTextbox.Size = new Size(200, 23);
            FirstNameTextbox.TabIndex = 5;
            // 
            // LastNameTextbox
            // 
            LastNameTextbox.BorderStyle = BorderStyle.FixedSingle;
            LastNameTextbox.Font = new Font("Lato", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            LastNameTextbox.Location = new Point(127, 92);
            LastNameTextbox.Name = "LastNameTextbox";
            LastNameTextbox.Size = new Size(200, 23);
            LastNameTextbox.TabIndex = 6;
            // 
            // RoleTextbox
            // 
            RoleTextbox.BorderStyle = BorderStyle.FixedSingle;
            RoleTextbox.Font = new Font("Lato", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            RoleTextbox.Location = new Point(127, 166);
            RoleTextbox.Name = "RoleTextbox";
            RoleTextbox.Size = new Size(200, 23);
            RoleTextbox.TabIndex = 8;
            // 
            // RoleLabel
            // 
            RoleLabel.AutoSize = true;
            RoleLabel.Font = new Font("Lato", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            RoleLabel.Location = new Point(12, 169);
            RoleLabel.Name = "RoleLabel";
            RoleLabel.Size = new Size(35, 16);
            RoleLabel.TabIndex = 7;
            RoleLabel.Text = "Role:";
            // 
            // DomainAccountTextbox
            // 
            DomainAccountTextbox.BorderStyle = BorderStyle.FixedSingle;
            DomainAccountTextbox.Font = new Font("Lato", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            DomainAccountTextbox.Location = new Point(127, 206);
            DomainAccountTextbox.Name = "DomainAccountTextbox";
            DomainAccountTextbox.Size = new Size(200, 23);
            DomainAccountTextbox.TabIndex = 10;
            // 
            // DomainNameLabel
            // 
            DomainNameLabel.AutoSize = true;
            DomainNameLabel.Font = new Font("Lato", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            DomainNameLabel.Location = new Point(12, 209);
            DomainNameLabel.Name = "DomainNameLabel";
            DomainNameLabel.Size = new Size(104, 16);
            DomainNameLabel.TabIndex = 9;
            DomainNameLabel.Text = "Domain Account:";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Font = new Font("Lato", 9.749999F, FontStyle.Regular, GraphicsUnit.Point);
            EmailLabel.Location = new Point(333, 209);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(111, 16);
            EmailLabel.TabIndex = 11;
            EmailLabel.Text = "@woordenschat.nl";
            // 
            // EmployeeSingleEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(EmailLabel);
            Controls.Add(DomainAccountTextbox);
            Controls.Add(DomainNameLabel);
            Controls.Add(RoleTextbox);
            Controls.Add(RoleLabel);
            Controls.Add(LastNameTextbox);
            Controls.Add(FirstNameTextbox);
            Controls.Add(BirthDateLabel);
            Controls.Add(BirthDateTimePicker);
            Controls.Add(LastNameLabel);
            Controls.Add(FirstNameLabel);
            Controls.Add(TitleLabel);
            Name = "EmployeeSingleEmployeeForm";
            Text = "EmployeeSingleEmployeeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Label FirstNameLabel;
        private Label LastNameLabel;
        private DateTimePicker BirthDateTimePicker;
        private Label BirthDateLabel;
        private TextBox FirstNameTextbox;
        private TextBox LastNameTextbox;
        private TextBox RoleTextbox;
        private Label RoleLabel;
        private TextBox DomainAccountTextbox;
        private Label DomainNameLabel;
        private Label EmailLabel;
    }
}