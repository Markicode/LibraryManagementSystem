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

namespace EmployeeApplication
{
    public partial class EmployeeServerConnectForm : Form
    {
        private Form parentForm;
        private ConnectionController connectionController;

        public EmployeeServerConnectForm(Form parentForm, ConnectionController connectionController)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.connectionController = connectionController;

            CloseButton.Enabled = false;
            connectionController.connected += EnableClosure;
            connectionController.disconnected += ShowMessage;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ConnectButton.Enabled = false;
            try
            {
                connectionController.ConnectToServer();
            }
            catch (Exception ex)
            {
                StatusLabel.Text = ex.Message;
                ConnectButton.Enabled = true;
            }
        }

        private void EnableClosure()
        {
            StatusLabel.Invoke(() => StatusLabel.Text = "Connected to server, you can now close this form.");
            CloseButton.Invoke(() => CloseButton.Enabled = true);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowMessage()
        {
            StatusLabel.Invoke(() => StatusLabel.Text = "Error connecting to server.");
        }
    }
}
