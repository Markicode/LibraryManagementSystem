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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UserApplication
{
    public partial class UserServerConnectForm : Form
    {
        private Form parentForm;
        private ConnectionController connectionController;

        public UserServerConnectForm(Form parentForm, ConnectionController connectionController)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.connectionController = connectionController;

            CloseButton.Enabled = false;
            connectionController.connected += EnableClosure;
            connectionController.disconnected += ShowMessage;
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            ConnectButton.Enabled = false;
            try
            {
                connectionController.serverIPAdress = IPTextbox.Text;
                connectionController.serverPort = Convert.ToUInt16(PortTextbox.Text);
                //connectionController.ConnectToServer();
                await connectionController.Connect(connectionController.connectionCancelToken);
            }
            catch (Exception ex)
            {
                StatusLabel.Invoke(() => StatusLabel.Text = ex.Message);
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
