using Controllers;
using LibraryModels;

namespace LibraryEmployeeApplication
{
    public partial class EmployeeLoginForm : Form
    {
        private AuthController authController;
        private User? user;

        public EmployeeLoginForm()
        {
            InitializeComponent();
            this.authController = new AuthController();
        }


        private void CheckButton_Click(object sender, EventArgs e)
        {
            switch (this.authController.AuthenticateUser(textBox1.Text, textBox2.Text))
            {
                case AuthController.AuthenticationResult.Success:
                    textBox1.BackColor = Color.Green;
                    textBox2.BackColor = Color.Green;
                    user = authController.GetPersonInfo(textBox1.Text);
                    label4.Text = user.password.ToString();
                    break;
                case AuthController.AuthenticationResult.Failed:
                    textBox1.BackColor = Color.Red;
                    textBox2.BackColor = Color.Red;
                    user = authController.GetPersonInfo(textBox1.Text);
                    label4.Text = user.password.ToString();
                    break;
                case AuthController.AuthenticationResult.NotFound:
                    textBox1.BackColor = Color.Yellow;
                    textBox2.BackColor = Color.Yellow;
                    break;
            }
            user = authController.GetPersonInfo(textBox1.Text);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                authController.AddUser(textBox1.Text, textBox2.Text);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            this.authController.UpdateUsers();
        }
    }
}
