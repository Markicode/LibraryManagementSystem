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

namespace EmployeeApplication
{
    public partial class EmployeeManageEmployeesForm : Form
    {
        private EmployeeMainForm parentForm;
        public EmployeeController employeeController;

        public EmployeeManageEmployeesForm(EmployeeMainForm parentForm, AuthController authController)
        {
            InitializeComponent();
            GoFullscreen(true);
            this.parentForm = parentForm;
            HomeLabel.Font = Style.menuFont;
            HomeLabel.ForeColor = Style.purpleColor;
            this.employeeController = new EmployeeController(parentForm.user);

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
