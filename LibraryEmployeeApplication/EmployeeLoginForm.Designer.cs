﻿namespace EmployeeApplication
{
    partial class EmployeeLoginForm
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
            CheckButton = new Button();
            label3 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // CheckButton
            // 
            CheckButton.Font = new Font("Lato", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CheckButton.ForeColor = Color.FromArgb(33, 0, 127);
            CheckButton.Location = new Point(124, 250);
            CheckButton.Name = "CheckButton";
            CheckButton.Size = new Size(75, 23);
            CheckButton.TabIndex = 13;
            CheckButton.Text = "Check";
            CheckButton.UseVisualStyleBackColor = true;
            CheckButton.Click += CheckButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lato", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(33, 0, 127);
            label3.Location = new Point(22, 212);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 12;
            label3.Text = "password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lato", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(33, 0, 127);
            label2.Location = new Point(43, 183);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 11;
            label2.Text = "email";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(85, 209);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(224, 23);
            textBox2.TabIndex = 9;
            textBox2.UseSystemPasswordChar = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(85, 180);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(224, 23);
            textBox1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = EmployeeApplication.Properties.Resources.Woordenschat_logoBMP_2klein;
            pictureBox1.Location = new Point(95, 55);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 73);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // EmployeeLoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(335, 314);
            Controls.Add(pictureBox1);
            Controls.Add(CheckButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "EmployeeLoginForm";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CheckButton;
        private Label label3;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox1;
        private PictureBox pictureBox1;
    }
}