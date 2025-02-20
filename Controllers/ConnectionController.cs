using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GlobalApplicationVariables;

namespace Controllers
{
    public class ConnectionController
    {
        public AuthController authController;
        public string serverIPAdress {  get; set; }
        public ushort serverPort {  get; set; }
        private TcpClient? client;
        private string? clientName;
        public CancellationTokenSource connectionCTS;
        public CancellationToken connectionCancelToken;
        public ManualResetEvent manualResetEvent;

        public delegate void disconnectedDelegate();
        public event disconnectedDelegate disconnected;
        public delegate void connectedDelegate();
        public event connectedDelegate connected;
        public delegate void emailCheckedDelegate(bool present);
        public event emailCheckedDelegate emailChecked;

        public ConnectionController() 
        {
            this.serverIPAdress = "127.0.0.1";
            this.serverPort = 8086;
            connectionCTS = new CancellationTokenSource();
            connectionCancelToken = connectionCTS.Token;
            manualResetEvent = new ManualResetEvent(false);
            this.authController = new AuthController(this);
            emailChecked += authController.SetEmailPresence;
        }

        public async void ConnectToServer()
        {
            await this.Connect(this.connectionCancelToken);
        }

        public async void SendMessageToServer(string message, Enumeration.CommGoal commGoal)
        {
            await this.Send(message, commGoal);
        }

        public Task Connect(CancellationToken connCancelToken)
        {
            Task connectTask = Task.Run(async () =>
            {
 
                this.client = new TcpClient(serverIPAdress, serverPort);
                this.clientName = System.Environment.MachineName;

                NetworkStream ns = client.GetStream();
                string data = "";
                string answer = "";
                string[] segments;

                if (this.clientName != null && client != null)
                {
                    // Send chatname to server
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(this.clientName);
                    ns.Write(bytesToSend, 0, bytesToSend.Length);

                    for (int i = 0; i < 1000000; i++)
                    {
                        if (ns.DataAvailable)
                        {
                            byte[] receivedBytes = new byte[1024];
                            int byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length);
                            data = Encoding.ASCII.GetString(receivedBytes, 0, byte_count);
                            segments = data.Split(new string[] { "~~~" }, StringSplitOptions.None);
                            if (segments[0] == Enumeration.CommGoal.ServerConnect.ToString())
                            {
                                answer = segments[1];   
                            }
                            break;
                        }
                        answer = "timeout";
                    }
                   

                    if (answer == "ok")
                    {
                        if (this.connected != null)
                        {
                            this.connected();
                        }
                    }
                    if (answer == "timeout")
                    {
                        await this.Disconnect();
                        if (this.disconnected != null)
                        {
                            this.disconnected();
                        }
                    }


                }

                else
                {
                    await this.Disconnect();
                    if (this.disconnected != null)
                    {
                        this.disconnected();
                    }
                }


                while (true)
                {
                    try
                    {

                        if (!connCancelToken.IsCancellationRequested)
                        {
                            if (ns.DataAvailable)
                            {
                                try
                                {
                                    await ReceiveData(client, connCancelToken);
                                }
                                catch (Exception e)
                                {
                                    //MessageBox.Show(e.ToString());
                                }
                            }
                        }
                        else
                        {
                            connCancelToken.ThrowIfCancellationRequested();
                        }
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }

                // TODO: proper cleanup and control functionality
                client.Client.Shutdown(SocketShutdown.Send);
                ns.Close();
                client.Close();
                if (this.disconnected != null)
                {
                    this.disconnected();
                }

            });
            return connectTask;
        }

        private Task Send(string message, Enumeration.CommGoal commGoal)
        {
            Task sendTask = Task.Run(() =>
            {
                try
                {
                    // Open stream and convert message to bytes
                    // Add nr.1 at the beginning to let the server know its a string message.
                    NetworkStream nwStream = client.GetStream();
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(commGoal + "~~~" + this.clientName + "~~~" + message);

                    // Send the message
                    nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
            });
            return sendTask;
        }

        private Task SendObject(object o)
        {
            Task sendObjectTask = Task.Run(() =>
            {
                try
                {
                    // Convert object to json string, open stream and send json string as byte array.
                    // Add nr. 2 at the beginning of the string to signal the server that it is receiving an object.
                    string jsonString = JsonSerializer.Serialize(o);
                    NetworkStream nwStream = client.GetStream();
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes("2~" + this.clientName + "~" + jsonString);

                    // Send the message
                    nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                    //MessageTextBox.Invoke(() => { MessageTextBox.Text = ""; });
                    //ChatTextBox.Invoke(() => { ChatTextBox.Text += "You sent an object \r\n"; });

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
            });
            return sendObjectTask;
        }

        private Task ReceiveData(TcpClient client, CancellationToken connCancelToken)
        {
            Task receiveDataTask = Task.Run(() =>
            {
                try
                {
                    NetworkStream ns = client.GetStream();
                    byte[] receivedBytes = new byte[1024];
                    int byte_count;

                    while (!connCancelToken.IsCancellationRequested)
                    {
                        if (ns.DataAvailable)
                        {
                            byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length);
                            string data = Encoding.ASCII.GetString(receivedBytes, 0, byte_count);
                            string[] segments = data.Split(new string[] {"~~~"}, StringSplitOptions.None);

                            if (segments[0] == Enumeration.CommGoal.EmailCheck.ToString())
                            {
                                if (segments[1] == "true")
                                {
                                    if(this.emailChecked != null) 
                                    {
                                        this.emailChecked(true);
                                    }
                                    manualResetEvent.Set();
                                }
                                if (segments[1] == "false")
                                {
                                    if (this.emailChecked != null)
                                    {
                                        this.emailChecked(false);
                                    }
                                    manualResetEvent.Set();
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    /*if (ex is OperationCanceledException)
                    {
                        MessageBox.Show($"Operation canceled");
                    }
                    else
                    {
                        MessageBox.Show("task recievedata error");
                    }*/

                }
                //ChatTextBox.Invoke(() => ChatTextBox.Text += "7");

            });
            return receiveDataTask;
        }

        private Task Disconnect()
        {
            Task disconnectTask = Task.Run(() =>
            {
                connectionCTS.Cancel();
                if (this.disconnected != null)
                {
                    this.disconnected();
                }
            });
            return disconnectTask;
        }

    }
}
