using LibraryEmployeeApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalApplicationVariables;
using Controllers;
using Models;

namespace EmployeeApplication
{
    public partial class EmployeeManageEmployeesForm : Form
    {
        private EmployeeMainForm parentForm;
        public EmployeeController employeeController;
        private int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        private int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        private List<Employee> employees; 

        public EmployeeManageEmployeesForm(EmployeeMainForm parentForm, AuthController authController)
        {
            InitializeComponent();
            GoFullscreen(true);
            this.parentForm = parentForm;
            HomeLabel.Font = Style.menuFont;
            HomeLabel.ForeColor = Style.purpleColor;
            this.employeeController = new EmployeeController(parentForm.user);
            EmployeesGridView.Location = new System.Drawing.Point(12, HomeLabel.Height + 18);
            EmployeesGridView.Size = new System.Drawing.Size(screenWidth - 20, screenHeight - HomeLabel.Height - InspectEmployeeButton.Height - 40);
            InspectEmployeeButton.Location = new System.Drawing.Point(12, screenHeight - InspectEmployeeButton.Height - 10);
            AddEmployeeButton.Location = new System.Drawing.Point(12 + InspectEmployeeButton.Width + 12, screenHeight - AddEmployeeButton.Height - 10);

            this.employees = this.employeeController.getAllEmployees();
            EmployeesGridView.DataSource = this.CreateEmployeeDataTable(this.employees);

            // Set your desired AutoSize Mode:
            EmployeesGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            EmployeesGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            EmployeesGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            EmployeesGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            EmployeesGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            EmployeesGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            EmployeesGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            EmployeesGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            /*// Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            for (int i = 0; i <= EmployeesGridView.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = EmployeesGridView.Columns[i].Width;

                // Remove AutoSizing:
                EmployeesGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                EmployeesGridView.Columns[i].Width = colw;
            }*/

            EmployeesGridView.AllowUserToAddRows = false;
            EmployeesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            EmployeesGridView.Font = Style.textFont;
        }

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

        private DataTable CreateEmployeeDataTable(List<Employee> employees)
        {
            DataTable dataTable = new DataTable("Employees");
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("First Name");
            dataTable.Columns.Add("Last Name");
            dataTable.Columns.Add("Birth Date");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("BSN");
            dataTable.Columns.Add("Salary");
            dataTable.Columns.Add("Date Started");

            DataRow dataRow;
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);

            for (int i = 0; i < employees.Count; i++)
            {
                dataRow = dataTable.NewRow();
                dataRow["id"] = employees[i].id;
                dataRow["First Name"] = employees[i].firstName;
                dataRow["Last Name"] = employees[i].lastName;
                dataRow["Birth Date"] = employees[i].birthDate;
                dataRow["Email"] = employees[i].account.email;
                dataRow["BSN"] = employees[i].bsn;
                dataRow["Salary"] = employees[i].salary;
                dataRow["Date Started"] = employees[i].dateStarted;
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        private void OpenEmployeeForm(string mode)
        {
            EmployeeSingleEmployeeForm employeeSingleEmployeeForm = new(mode, parentForm.authController, this.employeeController);
            employeeSingleEmployeeForm.ShowDialog();
        }

        private void HomeLabel_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }

        private void HomeLabel_MouseEnter(object sender, EventArgs e)
        {
            HomeLabel.Font = Style.hoverMenuFont;
        }

        private void HomeLabel_MouseLeave(object sender, EventArgs e)
        {
            HomeLabel.Font = Style.menuFont;
        }

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            this.OpenEmployeeForm("add");
        }

        private void InspectEmployeeButton_Click(object sender, EventArgs e)
        {
            this.OpenEmployeeForm("inspect");
        }
    }
}
