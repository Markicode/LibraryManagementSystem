using Controllers;

namespace LibraryEmployeeApplication
{
    public partial class EmployeeLoginForm : Form
    {
        private AuthController authController;

        public EmployeeLoginForm()
        {
            InitializeComponent();
            authController = new AuthController();
        }


        private void CheckButton_Click(object sender, EventArgs e)
        {
            switch (authController.AuthenticateUser(textBox1.Text, textBox2.Text))
            {
                case AuthController.AuthenticationResult.Success:
                    textBox1.BackColor = Color.Green;
                    textBox2.BackColor = Color.Green;
                    break;
                case AuthController.AuthenticationResult.Failed:
                    textBox1.BackColor = Color.Red;
                    textBox2.BackColor = Color.Red;
                    break;
                case AuthController.AuthenticationResult.NotFound:
                    textBox1.BackColor = Color.Yellow;
                    textBox2.BackColor = Color.Yellow;
                    break;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                //authController.AddUserToDatabase(textBox1.Text, textBox2.Text);
            }
        }
    }
}
