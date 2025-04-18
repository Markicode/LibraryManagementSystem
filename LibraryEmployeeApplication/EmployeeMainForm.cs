using Controllers;
using EmployeeApplication;
using EmployeeApplication.Properties;
using GlobalApplicationVariables;
using Models;
using Mysqlx.Notice;


//namespace LibraryEmployeeApplication
namespace EmployeeApplication
{
    public partial class EmployeeMainForm : Form
    {
        // Form variables declaration.
        private string language;

        public User? user { get; set; }
        private bool userLoggedIn;
        public AuthController authController;
        public NewsController newsController;
        public ConnectionController connectionController;
        public ClientDataController clientDataController;

        private List<Label> menuLabels;
        private Dictionary<Label, menuChoises> menuLabelAssignment;
        private Dictionary<menuChoises, string> menuChoisesDutch;
        private Dictionary<menuChoises, string> menuChoisesEnglish;
        private TableLayoutPanel NewsTablePanel;

        private readonly Image loginIcon = Resources.LoginbuttonBMP;
        private readonly Image logoutIcon = Resources.LogoutbuttonBMP;

        // Enumeration used to dynamically adjust the menu to the employees permissions. 
        public enum menuChoises
        {
            Login = 0, Intake = 1, Dispense = 2, SearchItem = 3, SearchPerson = 4, ItemManagement = 5, EmployeeManagement = 6, MemberManagement = 7, ConnectToServer = 8
        }

        public EmployeeMainForm()
        {
            InitializeComponent();
            //GoFullscreen(true);

            this.connectionController = new ConnectionController();
            this.clientDataController = new ClientDataController(connectionController);
            this.authController = connectionController.authController;
            this.newsController = new NewsController(clientDataController);
            this.AdjustLayout();

            MenuPicBox1.Image = loginIcon;
            this.userLoggedIn = false;
            this.language = "NL";
            this.menuLabels = new List<Label>() { MenuLabel1, MenuLabel2, MenuLabel3, MenuLabel4, MenuLabel5, MenuLabel6, MenuLabel7, MenuLabel8 };

            this.authController.LoggedIn += WelcomeUser;
            this.authController.LoggedOut += HideMenu;
            this.authController.LoggedOut += HideNews;
            this.connectionController.connected += EnableLogin;

            this.menuLabelAssignment = new Dictionary<Label, menuChoises>()
            {
                {MenuLabel1, menuChoises.Login},
                {MenuLabel2, menuChoises.Intake},
                {MenuLabel3, menuChoises.Dispense},
                {MenuLabel4, menuChoises.SearchItem},
                {MenuLabel5, menuChoises.SearchPerson},
                {MenuLabel6, menuChoises.MemberManagement},
                {MenuLabel7, menuChoises.ItemManagement},
                {MenuLabel8, menuChoises.EmployeeManagement}
            };
            this.menuChoisesDutch = new Dictionary<menuChoises, string>()
            {
                {menuChoises.Login, "Login"},
                {menuChoises.Intake, "Inname"},
                {menuChoises.Dispense, "Uitgave"},
                {menuChoises.SearchItem, "Zoek Item"},
                {menuChoises.SearchPerson, "Zoek Persoon"},
                {menuChoises.ItemManagement, "Beheer Items"},
                {menuChoises.EmployeeManagement, "Beheer Personeel"},
                {menuChoises.MemberManagement, "Beheer Leden" },
                {menuChoises.ConnectToServer, "Maak verbinding met de server"}
            };
            this.menuChoisesEnglish = new Dictionary<menuChoises, string>()
            {
                {menuChoises.Login, "Login"},
                {menuChoises.Intake, "Intake"},
                {menuChoises.Dispense, "Dispense"},
                {menuChoises.SearchItem, "Search Item"},
                {menuChoises.SearchPerson, "Search Person"},
                {menuChoises.ItemManagement, "Manage Items"},
                {menuChoises.EmployeeManagement, "Manage Employees"},
                {menuChoises.MemberManagement, "Manage Members"},
                {menuChoises.ConnectToServer, "Connect to the server"}
            };

            this.NewsTablePanel = new TableLayoutPanel();



            foreach (Label label in menuLabels)
            {
                label.Enabled = false;
                label.Visible = false;

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

        private void AdjustLayout()
        {
            LineLabel1.Width = (this.Width - 50);
            LineLabel2.Width = (this.Width - 50);

            if (NewsTablePanel != null)
            {
                NewsTablePanel.Height = (this.Height - 275);
                NewsTablePanel.Width = (this.Width - 290);
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
            this.user = user;
            WelcomeLabel.Text = $"Hallo {user.email}, gebruik het menu om te beginnen.";
            WelcomeLabel.Visible = true;
            this.userLoggedIn = true;
            this.EnableMenu();
            this.ShowNews();

        }

        private void EnableLogin()
        {
            foreach (Label label in menuLabels)
            {
                if (menuLabelAssignment[label] == menuChoises.Login)
                {
                    label.Invoke(() => label.Enabled = true);
                    label.Invoke(() => label.Visible = true);
                }
            }
        }

        private void EnableMenu()
        {
            MenuPicBox1.Image = logoutIcon;
            foreach (Label label in menuLabels)
            {
                label.Enabled = true;
                label.Visible = true;
            }
        }

        private void HideMenu()
        {
            foreach (Label label in menuLabels)
            {
                //if(!(menuLabelAssignment[label] == menuChoises.Login))
                //{
                label.Visible = false;
                label.Enabled = false;
                //}
            }
        }

        private void HideNews()
        {
            NewsTablePanel.Visible = false;
        }

        private async void ShowNews()
        {
            MessageBox.Show("About to show all news");
            List<NewsMessage> news = new List<NewsMessage>();
            news = await newsController.GetAllNews();
            if (news != null && news.Count > 0)
            {
                TableLayoutPanel[] messagePanels = new TableLayoutPanel[news.Count];
                Label[] titleLabels = new Label[news.Count];
                Label[] contentLabels = new Label[news.Count];
                PictureBox[] pictureBoxes = new PictureBox[news.Count];

                NewsTablePanel.ColumnCount = 1;
                NewsTablePanel.RowCount = news.Count;

                NewsTablePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                NewsTablePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                NewsTablePanel.RowStyles.Clear();
                NewsTablePanel.ColumnStyles.Clear();
                NewsTablePanel.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width - 275, Screen.PrimaryScreen.Bounds.Height - 250);
                NewsTablePanel.Location = new System.Drawing.Point(240, 220);
                NewsTablePanel.AutoScroll = true;
                this.Controls.Add(NewsTablePanel);
                NewsTablePanel.Visible = true;

                for (int i = 0; i < news.Count; i++)
                {
                    NewsTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                    NewsTablePanel.RowStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    messagePanels[i] = new TableLayoutPanel();
                    messagePanels[i].RowCount = 2;
                    messagePanels[i].ColumnCount = 2;
                    messagePanels[i].Dock = DockStyle.Fill;
                    messagePanels[i].AutoSize = true;
                    titleLabels[i] = new Label();
                    contentLabels[i] = new Label();
                    pictureBoxes[i] = new PictureBox();

                    NewsTablePanel.Controls.Add(messagePanels[i], 1, i);
                    pictureBoxes[i].Size = new System.Drawing.Size(300, 300);
                    pictureBoxes[i].Text = news[i].picture;
                    if (news[i].picture != null && news[i].picture != "")
                    {
                        pictureBoxes[i].Load(AppDirectory.newsImages + @"\" + news[i].picture);
                    }
                    else
                    {
                        pictureBoxes[i].Load(AppDirectory.newsImages + @"\news.bmp");
                    }

                    messagePanels[i].ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300));
                    messagePanels[i].ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    messagePanels[i].RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    messagePanels[i].RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    messagePanels[i].Controls.Add(titleLabels[i], 0, 0);
                    messagePanels[i].Controls.Add(pictureBoxes[i], 0, 1);
                    messagePanels[i].Controls.Add(contentLabels[i], 1, 1);
                    pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;

                    messagePanels[i].SetColumnSpan(titleLabels[i], 2);

                    titleLabels[i].AutoSize = true;
                    titleLabels[i].Text = news[i].title;
                    titleLabels[i].Font = Style.menuFont;
                    contentLabels[i].AutoSize = true;
                    contentLabels[i].Text = news[i].content;
                    contentLabels[i].Font = Style.textFont;

                    this.AdjustLayout();

                }
            }
        }

        private void DrawControlBorders(Control control, Color color)
        {
            System.Drawing.Pen pen = new System.Drawing.Pen(color);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.DrawRectangle(pen, new Rectangle(control.Location.X-1, control.Location.Y-1, control.Width+2, control.Height+2));
            pen.Dispose();
            formGraphics.Dispose();
        }

        private void OpenServerConnectionForm()
        {
            OpenForm(menuChoises.ConnectToServer);
        }

        private void OpenForm(menuChoises choise)
        {
            switch (choise)
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
                case menuChoises.ItemManagement:
                    {
                        EmployeeManageItemsForm employeeManageItemsForm = new EmployeeManageItemsForm(this);
                        employeeManageItemsForm.Show();
                        this.Hide();
                        break;
                    }
                case menuChoises.EmployeeManagement:
                    {
                        EmployeeManageEmployeesForm employeeManageEmployeesForm = new EmployeeManageEmployeesForm(this, this.authController);
                        employeeManageEmployeesForm.Show();
                        this.Hide();
                        break;
                    }
                case menuChoises.ConnectToServer:
                    {
                        EmployeeServerConnectForm employeeServerConnectForm = new EmployeeServerConnectForm(this, connectionController);
                        employeeServerConnectForm.ShowDialog();
                        break;
                    }
            }
        }

        public void Logout()
        {
            authController.LogoutUser();
            this.user = null;
            NewsTablePanel.Visible = false;
            this.userLoggedIn = false;
            MenuPicBox1.Image = loginIcon;

        }

        private void MenuLabel1_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel1.Font = Style.hoverMenuFont;
        }

        private void MenuLabel1_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel1.Font = Style.menuFont;
        }

        private void MenuLabel1_Click(object sender, EventArgs e)
        {
            OpenForm(menuLabelAssignment[MenuLabel1]);
        }

        private void MenuLabel2_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel2.Font = Style.hoverMenuFont;
        }

        private void MenuLabel2_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel2.Font = Style.menuFont;
        }

        private void MenuLabel2_Click(object sender, EventArgs e)
        {
            OpenForm(menuLabelAssignment[MenuLabel2]);
        }

        private void MenuLabel3_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel3.Font = Style.hoverMenuFont;
        }

        private void MenuLabel3_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel3.Font = Style.menuFont;
        }

        private void MenuLabel3_Click(object sender, EventArgs e)
        {
            OpenForm(menuLabelAssignment[MenuLabel3]);
        }

        private void MenuLabel4_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel4.Font = Style.hoverMenuFont;
        }

        private void MenuLabel4_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel4.Font = Style.menuFont;
        }

        private void MenuLabel4_Click(object sender, EventArgs e)
        {
            OpenForm(menuLabelAssignment[MenuLabel4]);
        }

        private void MenuLabel5_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel5.Font = Style.hoverMenuFont;
        }

        private void MenuLabel5_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel5.Font = Style.menuFont;
        }

        private void MenuLabel5_Click(object sender, EventArgs e)
        {
            OpenForm(menuLabelAssignment[MenuLabel5]);
        }

        private void MenuLabel6_Click(object sender, EventArgs e)
        {
            OpenForm(menuLabelAssignment[MenuLabel6]);
        }

        private void MenuLabel7_Click(object sender, EventArgs e)
        {
            OpenForm(menuLabelAssignment[MenuLabel7]);
        }

        private void MenuLabel6_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel6.Font = Style.hoverMenuFont;
        }

        private void MenuLabel6_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel6.Font = Style.menuFont;
        }

        private void MenuLabel7_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel7.Font = Style.hoverMenuFont;
        }

        private void MenuLabel7_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel7.Font = Style.menuFont;
        }

        private void MenuLabel8_MouseEnter(object sender, EventArgs e)
        {
            MenuLabel8.Font = Style.hoverMenuFont;
        }

        private void MenuLabel8_MouseLeave(object sender, EventArgs e)
        {
            MenuLabel8.Font = Style.menuFont;
        }

        private void MenuLabel8_Click(object sender, EventArgs e)
        {
            OpenForm(menuLabelAssignment[MenuLabel8]);
        }

        private void EmployeeMainForm_Load(object sender, EventArgs e)
        {
            this.OpenServerConnectionForm();
        }

        private void EmployeeMainForm_Resize(object sender, EventArgs e)
        {
            this.AdjustLayout();
        }

        private void MenuPicBox1_Click(object sender, EventArgs e)
        {
            if (!userLoggedIn)
            {
                OpenForm(menuLabelAssignment[MenuLabel1]);
            }
            else
            {
                this.Logout();
            }
        }

        private void MenuPicBox1_MouseEnter(object sender, EventArgs e)
        {
            this.DrawControlBorders(MenuPicBox1, Style.purpleColor);
        }

        private void MenuPicBox1_MouseLeave(object sender, EventArgs e)
        {
            this.DrawControlBorders(MenuPicBox1, Color.White);
        }
    }
}
