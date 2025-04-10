﻿using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GlobalApplicationVariables;
using Org.BouncyCastle.X509.Store;
using System.Threading.Tasks.Dataflow;
using Models;

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
        public ManualResetEvent manualResetDataSentEvent;
        public ManualResetEvent manualResetSetUserEvent;
        public BufferBlock<string> bufferBlock;

        public delegate void disconnectedDelegate();
        public event disconnectedDelegate disconnected;
        public delegate void connectedDelegate();
        public event connectedDelegate connected;
        //public delegate void userFoundDelegate(User user);
        //public event userFoundDelegate userFound;

        public ConnectionController() 
        {
            this.serverIPAdress = "127.0.0.1";
            this.serverPort = 8086;
            connectionCTS = new CancellationTokenSource();
            connectionCancelToken = connectionCTS.Token;
            manualResetDataSentEvent = new ManualResetEvent(false);
            manualResetSetUserEvent = new ManualResetEvent(false);
            this.authController = new AuthController(this);

            this.bufferBlock = new BufferBlock<string>();
            //userFound += authController.SetEmailPresence;

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
                            if (segments[1] == Enumeration.CommGoal.ServerConnect.ToString())
                            {
                                answer = segments[2];
                                answer = answer.Replace("~***~", "");
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
                    // Add communication goal to the start of the message to let the server know what to do with the information.
                    // To enforce the use of the right terminology, an enumeration is used available for server and client.
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
            Task receiveDataTask = Task.Run(async () =>
            {
                try
                {
                    NetworkStream ns = client.GetStream();
                    byte[] receivedBytes = new byte[1024];
                    int byte_count;
                    var builder = new StringBuilder();
                    // TODO: Handle bigger data 

                    while (!connCancelToken.IsCancellationRequested)
                    {
                        if (ns.DataAvailable)
                        {
                            string data = "";
                            bool firstMessagepart = true;
                            bool messageEnded = false;
                            
                            do
                            {
                                if (firstMessagepart)
                                {
                                    //byte_count = await ns.ReadAsync(receivedBytes, 0, receivedBytes.Length);
                                    // TODO: Check for message length
                                    byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length);
                                    data += Encoding.ASCII.GetString(receivedBytes, 0, byte_count);
                                    if (data.Contains("~***~"))
                                    {
                                        messageEnded = true;
                                    }
                                    firstMessagepart = false;
                                }
                                else
                                {
                                    byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length);
                                    data += Encoding.ASCII.GetString(receivedBytes, 0, byte_count);
                                    if (data.Contains("~***~"))
                                    {
                                        messageEnded = true;
                                    }
                                }

                            }
                            while(!messageEnded);

                            string[] segments = data.Split(new string[] {"~~~"}, StringSplitOptions.None);
                            string message = segments[2].Replace("~***~", "");

                            Enumeration.CommGoal commGoal = Enumeration.CommGoal.Unknown;
                            Enum.TryParse(segments[1], out commGoal);

                                switch (commGoal)
                                {
                                case Enumeration.CommGoal.Login:
                                    
                                    /*if (message == "true")
                                    {
                                        if (this.emailChecked != null)
                                        {
                                             this.emailChecked(true);
                                        }
                                            manualResetEvent.Set();
                                    }
                                    if (message == "false")
                                    {
                                        if (this.emailChecked != null)
                                        {
                                            this.emailChecked(false);
                                        }
                                        manualResetEvent.Set();
                                    }*/
                                    if(message == "null")
                                    {
                                        authController.ChangeUser(null);
                                        manualResetSetUserEvent.WaitOne();
                                        manualResetSetUserEvent.Reset();
                                        manualResetDataSentEvent.Set();
                                    }
                                    else
                                    {
                                        try
                                        {
                                            User user = JsonSerializer.Deserialize<User>(message);
                                            authController.ChangeUser(user);
                                            manualResetSetUserEvent.WaitOne();
                                            manualResetSetUserEvent.Reset();
                                            manualResetDataSentEvent.Set();
                                        }
                                        catch
                                        {
                                            authController.ChangeUser(null);
                                            manualResetSetUserEvent.WaitOne();
                                            manualResetSetUserEvent.Reset();
                                            manualResetDataSentEvent.Set();
                                        }
                                    }
                                    break;
                                case Enumeration.CommGoal.SendData:
                                    bufferBlock.Post(message);
                                    manualResetDataSentEvent.Set();
                                    break;
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
