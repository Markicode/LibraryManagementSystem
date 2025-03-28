using Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace LibraryEmployeeApplication
{
    public partial class EmployeeLoginForm : Form
    {
        private AuthController authController;
        private User? user;
        private EmployeeMainForm parentForm;

        public EmployeeLoginForm(EmployeeMainForm parentForm, AuthController authController)
        {
            InitializeComponent();
            this.authController = authController;
            this.parentForm = parentForm;
            textBox1.Text = "mark@test.nl";
            textBox2.Text = "12345678";
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            this.parentForm.user = null;
            switch (this.authController.AuthenticateUser(textBox1.Text, textBox2.Text))
            {
                case AuthController.AuthenticationResult.Success:
                    textBox1.BackColor = Color.Green;
                    textBox2.BackColor = Color.Green;
                    this.Close();
                    break;
                case AuthController.AuthenticationResult.Failed:
                    textBox1.BackColor = Color.Red;
                    textBox2.BackColor = Color.Red;
                    //user = authController.GetPersonInfo(textBox1.Text);
                    break;
                case AuthController.AuthenticationResult.NotFound:
                    textBox1.BackColor = Color.Yellow;
                    textBox2.BackColor = Color.Yellow;
                    break;
            }
            //user = authController.GetPersonInfo(textBox1.Text);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                authController.AddUser(textBox1.Text, textBox2.Text);
            }
        }
    }
}
