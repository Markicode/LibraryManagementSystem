using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryEmployeeApplication
{
    public partial class EmployeeMemberSearchForm : Form
    {
        private EmployeeMainForm parentForm;

        public EmployeeMemberSearchForm(EmployeeMainForm parentForm)
        {
            InitializeComponent();
            GoFullscreen(true);
            this.parentForm = parentForm;
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

        private void label1_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }
    }
}
