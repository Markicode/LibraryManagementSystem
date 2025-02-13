using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using ServerApplication;
using System.Text;
using System.Xml.Linq;

public class Server
{
    private IPAddress ipAdress {  get; set; }
    private ushort port { get; set; }

    private Dictionary<mainMenuOptions, string> mainMenuOptionsAssignment;
    private Dictionary<settingsMenuOptions, string> settingsMenuOptionsAssignment;

    public List<mainMenuOptions> mainMenuList;
    public List<settingsMenuOptions> settingsMenuList;

    //public event ListeningModeChangedDelegate ListeningModeChanged;
    //public delegate void ListeningModeChangedDelegate(string message);
    public event clientConnectedDelegate clientConnected;
    public delegate void clientConnectedDelegate(Client client);
    public event clientConnectedDelegate clientDisconnected;
    public delegate void clientDisconnectedDelegate(Client client);
    //public event operationFinishedDelegate operationFinished;
    //public delegate void operationFinishedDelegate();

    public bool isListening {get; set;}

    static readonly object _lock = new object();
    static readonly Dictionary<string, Client> clients = new Dictionary<string, Client>();
    TcpListener listener;

    CancellationTokenSource listenCancellationTokenSource;
    CancellationToken listenCancellationToken;

    CancellationTokenSource serverCancellationTokenSource;
    CancellationToken serverCancellationToken;

    public Server()
    {
        this.isListening = false;
        mainMenuOptionsAssignment = new Dictionary<mainMenuOptions, string>()
        {
            {mainMenuOptions.Settings, "Change server settings."},
            {mainMenuOptions.StartListening, "Start listening for clients."},
            {mainMenuOptions.StopListening, "Stop listening for clients."},
            {mainMenuOptions.ViewClients, "View all connected clients."},
            {mainMenuOptions.ViewLog, "View the latest log entries." },
            {mainMenuOptions.Close, "Close the server application." }
        };
        settingsMenuOptionsAssignment = new Dictionary<settingsMenuOptions, string>()
        {
            {settingsMenuOptions.SetIp, "Change the server IP-address."},
            {settingsMenuOptions.SetPort, "Change the server port."},
            {settingsMenuOptions.SetLogSize, "Adjust the number of shown log entries" },
            {settingsMenuOptions.Exit, "Exit to main menu."}
        };

        mainMenuList = new List<mainMenuOptions> {mainMenuOptions.Settings, mainMenuOptions.StartListening, mainMenuOptions.ViewLog, mainMenuOptions.ViewClients, mainMenuOptions.Close};
        settingsMenuList = new List<settingsMenuOptions> {settingsMenuOptions.SetIp, settingsMenuOptions.SetPort, settingsMenuOptions.SetLogSize, settingsMenuOptions.Exit};

        this.ipAdress = IPAddress.Parse("127.0.0.1");
        this.port = 8086;

        serverCancellationTokenSource = new CancellationTokenSource();
        serverCancellationToken = serverCancellationTokenSource.Token;
        listenCancellationTokenSource = new CancellationTokenSource();
        listenCancellationToken = listenCancellationTokenSource.Token;

        clientConnected += HandleClient;
    } 
    public enum mainMenuOptions
    {   
        Settings = 0, StartListening = 1, StopListening = 3, ViewClients = 4, ViewLog = 5, Close = 6
    }

    public enum settingsMenuOptions
    {
        SetIp = 0, SetPort = 1, SetLogSize = 3, Exit = 4
    }

    public void Start()
    {
        this.ShowMainMenu();
        while (!serverCancellationToken.IsCancellationRequested)
        {

        }
        Environment.Exit(0);
    }

    public async void ShowMainMenu()
    {
        Dictionary<int, mainMenuOptions> mainMenu = this.MakeDictionary(mainMenuList);
        Console.WriteLine("Main menu options:");
        foreach(KeyValuePair<int, mainMenuOptions> mainOption in mainMenu)
        {
            string choiseText = string.Format("{0}. {1, -5}", mainOption.Key, mainMenuOptionsAssignment[mainOption.Value]);
            Console.WriteLine(choiseText);
        }
        Console.WriteLine("");
        int mainChoise = ValidateMenuChoise(mainMenuList.Count);
        mainMenuOptions chosenOption = mainMenu[mainChoise];
        switch (chosenOption)
        {
            case mainMenuOptions.StartListening:
                {
                    await this.Listen(this.ipAdress, this.port);
                    break;
                }
            case mainMenuOptions.StopListening:
                {
                    listenCancellationTokenSource.Cancel();      
                    break;
                }
            case mainMenuOptions.Settings:
                {
                    Console.Clear();
                    this.ShowSettingsMenu();
                    break;
                }
            case mainMenuOptions.ViewClients:
                {
                    this.ViewClients();
                    break;
                }
            case mainMenuOptions.ViewLog:
                {
                    this.ViewLog();
                    break;
                }
            case mainMenuOptions.Close:
                {
                    serverCancellationTokenSource.Cancel();
                    break;
                }
        }

    }

    public void ViewLog()
    {
        this.RefreshScreen("Here are the latest log entries: \r\n", "main");
    }

    public void ShowSettingsMenu()
    {
        Dictionary<int, settingsMenuOptions> settingsMenu = this.MakeDictionary(settingsMenuList);
        Console.WriteLine("Settings menu options:");
        foreach (KeyValuePair<int, settingsMenuOptions> settingOption in settingsMenu)
        {
            string choiseText = string.Format("{0}. {1, -5}", settingOption.Key, settingOption.Value.ToString());
            Console.WriteLine(choiseText);
        }
        Console.WriteLine("");
        int settingChoise = ValidateMenuChoise(settingsMenuList.Count);
        settingsMenuOptions chosenOption = settingsMenu[settingChoise];
        switch (chosenOption)
        {
            case settingsMenuOptions.SetIp:
                {
                    Console.WriteLine("Current IP adress is: " + this.ipAdress.ToString());
                    Console.WriteLine("Please enter the IP Adress for this server: \r\n");
                    // TODO: IP input validation (regex)
                    this.ipAdress = IPAddress.Parse(Console.ReadLine());
                    this.RefreshScreen("Your IP adress has successfully been changed to: " + this.ipAdress.ToString(), "settings");
                    break;
                }
            case settingsMenuOptions.SetPort:
                {
                    Console.WriteLine("Current Port is: " + this.port.ToString());
                    Console.WriteLine("Please enter the port for this server: \r\n");
                    // TODO: Port input validation (regex)
                    this.port = Convert.ToUInt16(Console.ReadLine());
                    this.RefreshScreen("Your port has successfully been changed to: " + this.port.ToString(), "settings");
                    break;
                }
            case settingsMenuOptions.Exit:
                {
                    this.ShowMainMenu();
                    break;
                }
        }
    }

    public void updateMainMenu()
    {
        if(this.isListening)
        {
            if(mainMenuList.Contains(mainMenuOptions.StartListening))
            {
                mainMenuList.Remove(mainMenuOptions.StartListening);
                mainMenuList.Add(mainMenuOptions.StopListening);
            }
        }
        if(!this.isListening)
        {
            if(mainMenuList.Contains(mainMenuOptions.StopListening))
            {
                mainMenuList.Remove(mainMenuOptions.StopListening);
                mainMenuList.Add(mainMenuOptions.StartListening);
            }
        }
        
    }

    private Task Listen(IPAddress ipAddress, int port)
    {
        Task listenTask = Task.Run(async () =>
        {

            // Listen at specified ip/port.
            listener = new TcpListener(ipAddress, port);
            listener.Start();
            this.isListening = true;
            Task.Run(() => RefreshScreen("Server is listening.", "main"));

            // listen loop as long as task is not canceled.
            while (!listenCancellationToken.IsCancellationRequested)
            {
                //Console.WriteLine("1");
                await AcceptClients();
            }
            listener.Stop();
            this.isListening = false;
            Task.Run(() => RefreshScreen("Server stopped listening.", "main"));
        });
        return listenTask;
    }

    public void RefreshScreen(string message, string nextMenu)
    {
        this.updateMainMenu();
        Console.Clear();
        Console.WriteLine(message + "\r\n");
        switch(nextMenu)
        {
            case "main":
                {
                    this.ShowMainMenu();
                    break;
                }
            case "settings":
                {
                    this.ShowSettingsMenu();
                    break;
                }
                
        }
    }

    private Task AcceptClients()
    {
        Task acceptClientsTask = Task.Run(async () =>
        {
            // If there are no clients pending to connect, continue listening. 
            for (int i = 0; i < 5; i++)
            {
                if (!listener.Pending())
                {
                    //Console.WriteLine("2");
                    continue;
                }

                // In case a client does want to connect, it is assigned to client variable.
                // The client will send its name given clientside, and the name will be checked for availability in the clients dictionary.
                // The server will respond with a taken or free message.
                TcpClient tcpClient = listener.AcceptTcpClient();
                string clientName = await ReceiveName(tcpClient);
                

                /*foreach (var c in clients)
                {
                    if (c.Key == clientName)
                    {
                        // If the name is taken, the code will end without the client being added to the dictionary
                        this.duplicateClientAttempted(clientName + " attempted to connect. Name already in use, Connection denied.");
                        await this.Send("taken", tcpClient);
                        nameTaken = true;
                        break;
                    }

                }*/

                //if (!nameTaken)
                //{
                    // if the name is free, the client will be added to the dictionary and the clientconnected event will be invoked.
                    Client client = new Client(tcpClient, clientName);
                    lock (_lock) clients.Add(clientName, client);
                    //string chatters = "";
                    //lock (_lock)
                    //{
                    //    if (clients.Count > 0)
                    //    {
                    //        foreach (string chatter in clients.Keys)
                    //        {
                    //            chatters += chatter + ",";
                    //        }
                    //    }
                    //}
                    //chatters = chatters.Remove(chatters.Length - 1);
                    await this.Send("ok", tcpClient);
                    this.clientConnected(client);
                    //Console.WriteLine(clientName + "  connected.\r\n");
                

            }
        });
        return acceptClientsTask;
    }
    private async void HandleClient(Client client)
    {
        Task handleClientsTask = Task.Run(async () =>
        {
            Client clientToHandle = client;
            lock (_lock) clientToHandle = clients[client.clientName];

            while (true)
            {
                try
                {
                    NetworkStream nwStream = clientToHandle.tcpClient.GetStream();
                    byte[] buffer = new byte[1024];
                    int byteCount = nwStream.Read(buffer, 0, buffer.Length);

                    if (byteCount == 0)
                    {
                        break;
                    }

                    string data = Encoding.ASCII.GetString(buffer, 0, byteCount);
                    Console.WriteLine(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    break;
                }
            }

            lock (_lock) clients.Remove(clientToHandle.clientName);
            clientToHandle.tcpClient.Client.Shutdown(SocketShutdown.Both);
            clientToHandle.tcpClient.Close();
            //this.clientDisconnected(clientToHandle);
            //Console.WriteLine(clientToHandle.clientName + " disconnected \r\n");
        });
        await handleClientsTask;
    }

    private Task Send(string message, TcpClient client)
    {
        Task sendTask = Task.Run(() =>
        {
            try
            {
                // Open stream and convert message to bytes
                NetworkStream nwStream = client.GetStream();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(message);

                // Send the message
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        });
        return sendTask;
    }

    private Task<string> ReceiveName(TcpClient client)
    {
        return Task.Run(() =>
        {
            string name = "";
            bool nameReceived = false;
            while (!nameReceived)
            {
                NetworkStream nwStream = client.GetStream();
                if (nwStream.DataAvailable)
                {
                    byte[] buffer = new byte[1024];
                    int byteCount = nwStream.Read(buffer, 0, buffer.Length);
                    name = Encoding.ASCII.GetString(buffer, 0, byteCount);
                    nameReceived = true;
                    break;
                }    
            }
            return name;
        });
    }

    public void ViewClients()
    {
        string clientsListString = "Here is a list of the connected clients: \r\n \r\n";
        lock (_lock)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                clientsListString += string.Format("{0}. {1, -5} \r\n", i, clients.ElementAt(i).Key);
            }
        }
        this.RefreshScreen(clientsListString, "main");

    }

    private Dictionary<int, TValue> MakeDictionary<TValue>(List<TValue> list)
    {
        Dictionary<int, TValue> dictionary = new Dictionary<int, TValue>();
        for (int i = 1; i <= list.Count; i++)
        {
            // object 0 uit de list, wordt optie 1 in het menu.
            dictionary.Add(i, list[i - 1]);
        }
        return dictionary;
    }

    private int ValidateMenuChoise(int NumberOfChoises)
    {
        bool validChoise = false;
        int choise = 0;
        do
        {
            try
            {
                choise = Int32.Parse(Console.ReadLine());
                if (choise > 0 && choise <= NumberOfChoises)
                {
                    validChoise = true;
                    return choise;
                }
                else
                {
                    Console.WriteLine("Enter a number from the menu:");
                }
            }
            catch (FormatException formEx)
            {
                Console.WriteLine("Unvalid choise, enter a number:");
            }
            catch (OverflowException overflowEx)
            {
                Console.WriteLine("Number is too big, enter a valid number from the menu:");
            }
        }
        while (!validChoise);

        return choise;
    }


}