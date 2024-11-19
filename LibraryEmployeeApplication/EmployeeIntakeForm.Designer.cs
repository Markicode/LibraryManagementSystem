namespace EmployeeApplication
{
    partial class EmployeeIntakeForm
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lato", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(33, 0, 127);
            label1.Location = new Point(23, 26);
            label1.Name = "label1";
            label1.Size = new Size(224, 25);
            label1.TabIndex = 1;
            label1.Text = "Terug naar Hoofdmenu";
            label1.Click += label1_Click;
            // 
            // EmployeeIntakeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Name = "EmployeeIntakeForm";
            Text = "EmployeeIntakeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}