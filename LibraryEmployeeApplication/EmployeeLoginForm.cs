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
            label1.Text = loginController.ReadFromDatabase();
        }
    }
}
