using Controllers;
using LibraryModels;
using Mysqlx.Notice;

namespace LibraryEmployeeApplication
{
    public partial class EmployeeMainForm : Form
    {

        public EmployeeMainForm()
        {
            InitializeComponent();
            GoFullscreen(true);

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

        private void CloseButtonLabel_MouseEnter(object sender, EventArgs e)
        {
            CloseButtonLabel.Font = new Font(CloseButtonLabel.Font, FontStyle.Bold);
        }

        private void CloseButtonLabel_MouseLeave(object sender, EventArgs e)
        {
            CloseButtonLabel.Font = new Font(CloseButtonLabel.Font, FontStyle.Regular);
        }

        private void CloseButtonLabel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuLabel1_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel1.Font = new Font(MenuLabel1.Font, FontStyle.Bold);
        }

        private void MenuLabel1_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel1.Font = new Font(MenuLabel1.Font, FontStyle.Regular);
        }

        private void MenuLabel1_Click(object sender, EventArgs e)
        {
            EmployeeLoginForm employeeLoginForm = new EmployeeLoginForm();
            employeeLoginForm.ShowDialog();
        }
    }
}
