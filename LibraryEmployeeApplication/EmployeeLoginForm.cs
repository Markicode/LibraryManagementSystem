using Controllers;

namespace LibraryEmployeeApplication
{
    public partial class EmployeeLoginForm : Form
    {
        private LoginController loginController;

        public EmployeeLoginForm()
        {
            InitializeComponent();
            loginController = new LoginController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label1.Text = loginController.ReadFromDatabase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                loginController.AddUserToDatabase(textBox1.Text, textBox2.Text);
            }
            
        }
    }
}
