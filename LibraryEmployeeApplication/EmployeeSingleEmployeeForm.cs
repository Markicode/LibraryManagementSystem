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
    public partial class EmployeeSingleEmployeeForm : Form
    {
        private Employee activeEmployee;

        public EmployeeSingleEmployeeForm(string mode, AuthController authController, EmployeeController employeeController)
        {
            InitializeComponent();
            TitleLabel.ForeColor = Style.purpleColor;

            this.activeEmployee = employeeController.activeEmployee;

            if (mode == "inspect")
            {
                FirstNameTextbox.Text = activeEmployee.id.ToString() + " " + activeEmployee.userId.ToString() + " " + activeEmployee.firstName;
                LastNameTextbox.Text = activeEmployee.lastName;
                RoleTextbox.Text = employeeController.user.role;
                BirthDateTimePicker.Value = activeEmployee.birthDate;
            }
        }
    }
}
