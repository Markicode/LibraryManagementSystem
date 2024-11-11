namespace LibraryEmployeeApplication
{
    partial class EmployeeLoginForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            AddButton = new Button();
            label2 = new Label();
            label3 = new Label();
            CheckButton = new Button();
            label1 = new Label();
            label4 = new Label();
            UpdateButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(376, 103);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(224, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(376, 132);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(224, 23);
            textBox2.TabIndex = 3;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(376, 170);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 23);
            AddButton.TabIndex = 4;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(334, 106);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 5;
            label2.Text = "email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 135);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 6;
            label3.Text = "password";
            // 
            // CheckButton
            // 
            CheckButton.Location = new Point(457, 170);
            CheckButton.Name = "CheckButton";
            CheckButton.Size = new Size(75, 23);
            CheckButton.TabIndex = 7;
            CheckButton.Text = "Check";
            CheckButton.UseVisualStyleBackColor = true;
            CheckButton.Click += CheckButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(250, 242);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 8;
            label1.Text = "Hashed Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(359, 242);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 9;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(81, 60);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(75, 23);
            UpdateButton.TabIndex = 10;
            UpdateButton.Text = "Update Users";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // EmployeeLoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UpdateButton);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(CheckButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(AddButton);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "EmployeeLoginForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private TextBox textBox2;
        private Button AddButton;
        private Label label2;
        private Label label3;
        private Button CheckButton;
        private Label label1;
        private Label label4;
        private Button UpdateButton;
    }
}
