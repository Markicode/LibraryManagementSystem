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
        private AuthController authController;
        private EmployeeController employeeController;

        public EmployeeSingleEmployeeForm(string mode, AuthController authController, EmployeeController employeeController)
        {
            InitializeComponent();
            TitleLabel.ForeColor = Style.purpleColor;

            this.activeEmployee = employeeController.activeEmployee;
            this.authController = authController;
            this.employeeController = employeeController;

            if (mode == "inspect")
            {
                FirstNameTextbox.Text = activeEmployee.id.ToString() + " " + activeEmployee.userId.ToString() + " " + activeEmployee.firstName;
                LastNameTextbox.Text = activeEmployee.lastName;
                RoleTextbox.Text = employeeController.user.role;
                BirthDateTimePicker.Value = activeEmployee.birthDate;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // TODO: sanitize / check user input
            string firstName = FirstNameTextbox.Text;
            string lastName = LastNameTextbox.Text;
            string email = DomainAccountTextbox.Text + "@woordenschat.nl";
            string password = authController.HashPassword("Welkom123!");
            string role = "employee";
            DateTime birthDate = BirthDateTimePicker.Value;
            string bsn = BsnTextbox.Text;
            double salary = Convert.ToDouble(SalaryTextbox.Text);

            User user = new User(email, password, role);
            Employee employee = new Employee(0, 0, firstName, lastName, birthDate, 0, bsn, salary, DateTime.Now, user);
             

            employeeController.addEmployee(employee, user);
        }
    }
}
