using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Controllers
{
    public class ConnectionController
    {
        public string serverIPAdress {  get; set; }
        public ushort serverPort {  get; set; }
        private TcpClient? client;
        private string? chatName;
        CancellationTokenSource connectionCTS;
        CancellationToken connectionCancelToken;

        public delegate void disconnectedDelegate();
        public event disconnectedDelegate disconnected;
        public delegate void connectedDelegate();
        public event connectedDelegate connected;

        public ConnectionController() 
        {
            this.serverIPAdress = "127.0.0.1";
            this.serverPort = 8086;
            connectionCTS = new CancellationTokenSource();
            connectionCancelToken = connectionCTS.Token;
        }

        public async void ConnectToServer()
        {
            await this.Connect(this.connectionCancelToken);
        }

        private Task Connect(CancellationToken connCancelToken)
        {
            Task connectTask = Task.Run(async () =>
            {
                //try
                //{
                    this.client = new TcpClient(serverIPAdress, serverPort);
                    this.chatName = System.Environment.MachineName;
                //}
                //catch (Exception ex)
                //{

                //}

                NetworkStream ns = client.GetStream();
                string answer = "";

                if (this.chatName != null && client != null)
                {
                    // Send chatname to server
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(this.chatName);
                    ns.Write(bytesToSend, 0, bytesToSend.Length);

                    for (int i = 0; i < 10000; i++)
                    {
                        if (ns.DataAvailable)
                        {
                            byte[] receivedBytes = new byte[1024];
                            int byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length);
                            answer = Encoding.ASCII.GetString(receivedBytes, 0, byte_count);
                            break;
                        }
                        else
                        {
                            answer = "timeout";
                            
                        }
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
                        /*if (ex is OperationCanceledException)
                        {
                            ChatTextBox.Invoke(() => ChatTextBox.Text += $"Disconnected by user \r\n");
                            ConnectButton.Invoke(() => { ConnectButton.Text = "Connect"; });
                            break;
                        }
                        else
                        {
                            MessageBox.Show($"Other exception");
                            ConnectButton.Invoke(() => { ConnectButton.Text = "Connect"; });
                            break;
                        }*/
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

        private Task Send(string message)
        {
            Task sendTask = Task.Run(() =>
            {
                try
                {
                    // Open stream and convert message to bytes
                    // Add nr.1 at the beginning to let the server know its a string message.
                    NetworkStream nwStream = client.GetStream();
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes("1~" + this.chatName + "~" + message);

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
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes("2~" + this.chatName + "~" + jsonString);

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
