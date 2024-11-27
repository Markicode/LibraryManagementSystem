namespace EmployeeApplication
{
    partial class EmployeeManageEmployeesForm
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
            HomeLabel = new Label();
            dataGridView1 = new DataGridView();
            InspectEmployeeButton = new Button();
            AddEmployeeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // HomeLabel
            // 
            HomeLabel.AutoSize = true;
            HomeLabel.Location = new Point(12, 9);
            HomeLabel.Name = "HomeLabel";
            HomeLabel.Size = new Size(128, 15);
            HomeLabel.TabIndex = 0;
            HomeLabel.Text = "Terug naar hoofdmenu";
            HomeLabel.Click += HomeLabel_Click;
            HomeLabel.MouseEnter += HomeLabel_MouseEnter;
            HomeLabel.MouseLeave += HomeLabel_MouseLeave;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 1;
            // 
            // InspectEmployeeButton
            // 
            InspectEmployeeButton.Location = new Point(12, 415);
            InspectEmployeeButton.Name = "InspectEmployeeButton";
            InspectEmployeeButton.Size = new Size(128, 23);
            InspectEmployeeButton.TabIndex = 2;
            InspectEmployeeButton.Text = "Inspect Employee";
            InspectEmployeeButton.UseVisualStyleBackColor = true;
            InspectEmployeeButton.Click += InspectEmployeeButton_Click;
            // 
            // AddEmployeeButton
            // 
            AddEmployeeButton.Location = new Point(146, 415);
            AddEmployeeButton.Name = "AddEmployeeButton";
            AddEmployeeButton.Size = new Size(136, 23);
            AddEmployeeButton.TabIndex = 3;
            AddEmployeeButton.Text = "Add Employee";
            AddEmployeeButton.UseVisualStyleBackColor = true;
            AddEmployeeButton.Click += AddEmployeeButton_Click;
            // 
            // EmployeeManageEmployeesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddEmployeeButton);
            Controls.Add(InspectEmployeeButton);
            Controls.Add(dataGridView1);
            Controls.Add(HomeLabel);
            Name = "EmployeeManageEmployeesForm";
            Text = "EmployeeManageEmployeesForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HomeLabel;
        private DataGridView dataGridView1;
        private Button InspectEmployeeButton;
        private Button AddEmployeeButton;
    }
}