using Controllers;
using EmployeeApplication;
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
        private string language;
        public AuthController authController { get; set; }

        private List<Label> menuLabels;
        private Dictionary<Label, menuChoises> menuLabelAssignment;
        private Dictionary<menuChoises, string> menuChoisesDutch;
        private Dictionary<menuChoises, string> menuChoisesEnglish;

        public enum menuChoises
        {
            Login = 0, Intake = 1, Dispense = 2, SearchItem = 3, SearchPerson = 4
        }

        public EmployeeMainForm()
        {
            InitializeComponent();
            GoFullscreen(true);

            this.authController = new AuthController();
            this.fontFamily = new FontFamily("Lato");
            this.menuFont = new Font(this.fontFamily, 16, FontStyle.Regular);
            this.hoverMenuFont = new Font(this.fontFamily, 16, FontStyle.Bold);
            this.closeButtonFont = new Font(this.fontFamily, 24, FontStyle.Regular);
            this.hoverCloseButtonFont = new Font(this.fontFamily, 24, FontStyle.Bold);
            this.language = "NL";
            this.menuLabels = new List<Label>() { MenuLabel1, MenuLabel2, MenuLabel3, MenuLabel4, MenuLabel5 };
            this.authController.LoggedIn += UpdateMenu;

            this.menuLabelAssignment = new Dictionary<Label, menuChoises>()
            {
                {MenuLabel1, menuChoises.Login},
                {MenuLabel2, menuChoises.Intake},
                {MenuLabel3, menuChoises.Dispense},
                {MenuLabel4, menuChoises.SearchItem},
                {MenuLabel5, menuChoises.SearchPerson}
            };

            this.menuChoisesDutch = new Dictionary<menuChoises, string>()
            {
                {menuChoises.Login, "Login"},
                {menuChoises.Intake, "Inname"},
                {menuChoises.Dispense, "Uitgave"},
                {menuChoises.SearchItem, "Zoek Item"},
                {menuChoises.SearchPerson, "Zoek Persoon"}
            };
            this.menuChoisesEnglish = new Dictionary<menuChoises, string>()
            {
                {menuChoises.Login, "Login"},
                {menuChoises.Intake, "Intake"},
                {menuChoises.Dispense, "Dispense"},
                {menuChoises.SearchItem, "Search Item"},
                {menuChoises.SearchPerson, "Search Person"}
            };

            foreach (Label label in menuLabels)
            {
                label.Enabled = false;
                if (menuLabelAssignment[label] == menuChoises.Login)
                {
                    label.Enabled = true;
                }

                if (this.language == "NL")
                {
                    label.Text = menuChoisesDutch[menuLabelAssignment[label]];
                }
                if (this.language == "EN")
                {
                    label.Text = menuChoisesEnglish[menuLabelAssignment[label]];
                }
            }


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

        public void WelcomeUser(User user)
        {
            label1.Text = $"Hallo {user.email}, gebruik het menu om te beginnen.";
        }

        private void OpenForm(menuChoises choise)
        {
            switch(choise)
            {
                case menuChoises.Login:
                    {
                        EmployeeLoginForm employeeLoginForm = new EmployeeLoginForm(this, authController);
                        employeeLoginForm.ShowDialog();
                        break;
                    }
                case menuChoises.Intake:
                    {
                        EmployeeIntakeForm employeeIntakeForm = new EmployeeIntakeForm(this);
                        employeeIntakeForm.Show();
                        this.Hide();
                        break;
                    }
                case menuChoises.Dispense:
                    {
                        EmployeeDispenseForm employeeDispenseForm = new EmployeeDispenseForm(this);
                        employeeDispenseForm.Show();
                        this.Hide();
                        break;
                    }
                case menuChoises.SearchItem:
                    {
                        EmployeeItemSearchForm employeeItemSearchForm = new EmployeeItemSearchForm(this);
                        employeeItemSearchForm.Show();
                        this.Hide();
                        break;
                    }
                case menuChoises.SearchPerson:
                    {
                        EmployeeMemberSearchForm employeeMemberSearchForm = new EmployeeMemberSearchForm(this);
                        employeeMemberSearchForm.Show();
                        this.Hide();
                        break;
                    }
            }
        }

        private void UpdateMenu()
        {
            foreach (Label label in menuLabels)
            {
                label.Enabled = true;
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
            OpenForm(menuLabelAssignment[MenuLabel1]);
        }

        private void MenuLabel2_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel2.Font = this.hoverMenuFont;
        }

        private void MenuLabel2_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel2.Font = this.menuFont;
        }

        private void MenuLabel2_Click(object sender, EventArgs e)
        {
            OpenForm(menuLabelAssignment[MenuLabel2]);
        }

        private void MenuLabel3_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel3.Font = this.hoverMenuFont;
        }

        private void MenuLabel3_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel3.Font = this.menuFont;
        }

        private void MenuLabel3_Click(object sender, EventArgs e)
        {
            OpenForm(menuLabelAssignment[MenuLabel3]);
        }

        private void MenuLabel4_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel4.Font = this.hoverMenuFont;
        }

        private void MenuLabel4_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel4.Font = this.menuFont;
        }

        private void MenuLabel4_Click(object sender, EventArgs e)
        {
            OpenForm(menuLabelAssignment[MenuLabel4]);
        }

        private void MenuLabel5_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel5.Font = this.hoverMenuFont;
        }

        private void MenuLabel5_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel5.Font = this.menuFont;
        }

        private void MenuLabel5_Click(object sender, EventArgs e)
        {
            OpenForm(menuLabelAssignment[MenuLabel5]);
        }
    }
}
