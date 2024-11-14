using Controllers;
using LibraryModels;
using Mysqlx.Notice;

namespace LibraryEmployeeApplication
{
    public partial class EmployeeMainForm : Form
    {
        private FontFamily fontFamily;
        private Font menuFont;
        private Font hoverMenuFont;
        private Font closeButtonFont;
        private Font hoverCloseButtonFont;
        public User? user { get; set; }

        public EmployeeMainForm()
        {
            this.fontFamily = new FontFamily("Lato");
            this.menuFont = new Font(this.fontFamily, 16, FontStyle.Regular);
            this.hoverMenuFont = new Font(this.fontFamily, 16, FontStyle.Bold);
            this.closeButtonFont = new Font(this.fontFamily, 24, FontStyle.Regular);
            this.hoverCloseButtonFont = new Font(this.fontFamily, 24, FontStyle.Bold);

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
            CloseButtonLabel.Font = this.hoverCloseButtonFont;
        }

        private void CloseButtonLabel_MouseLeave(object sender, EventArgs e)
        {
            CloseButtonLabel.Font = this.closeButtonFont;
        }

        private void CloseButtonLabel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuLabel1_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel1.Font = this.hoverMenuFont;
        }

        private void MenuLabel1_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel1.Font = this.menuFont;
        }

        private void MenuLabel1_Click(object sender, EventArgs e)
        {
            EmployeeLoginForm employeeLoginForm = new EmployeeLoginForm(this);
            employeeLoginForm.ShowDialog();
        }

        public void WelcomeUser(User user)
        {
            label1.Text = $"Hallo {user.email}, gebruik het menu om te beginnen.";
        }

        private void MenuLabel3_Click(object sender, EventArgs e)
        {
            EmployeeMemberSearchForm employeeMemberSearchForm = new EmployeeMemberSearchForm(this);
            employeeMemberSearchForm.Show();
            this.Hide();
        }

        private void MenuLabel2_Click(object sender, EventArgs e)
        {
            EmployeeItemSearchForm employeeItemSearchForm = new EmployeeItemSearchForm();
            employeeItemSearchForm.Show();
            this.Hide();
        }
    }
}
