public class Server
{
    private Dictionary<mainMenuOptions, string> mainMenuOptionsAssignment;
    private Dictionary<settingsMenuOptions, string> settingsMenuOptionsAssignment;

    public List<mainMenuOptions> mainMenuList;
    public List<settingsMenuOptions> settingsMenuList;

    public bool isListening {get; set;}

    public Server()
    {
        this.isListening = false;
        mainMenuOptionsAssignment = new Dictionary<mainMenuOptions, string>()
        {
            {mainMenuOptions.Settings, "Change server settings."},
            {mainMenuOptions.StartListening, "Start listening for clients."},
            {mainMenuOptions.StopListening, "Stop listening for clients."},
            {mainMenuOptions.ViewClients, "View all connected clients."}
        };
        settingsMenuOptionsAssignment = new Dictionary<settingsMenuOptions, string>()
        {
            {settingsMenuOptions.SetIp, "Change the server IP-address."},
            {settingsMenuOptions.SetPort, "Change the server port."}
        };

        mainMenuList = new List<mainMenuOptions> {mainMenuOptions.Settings, mainMenuOptions.StartListening, mainMenuOptions.ViewClients};
        settingsMenuList = new List<settingsMenuOptions> {settingsMenuOptions.SetIp, settingsMenuOptions.SetPort};
    } 
    public enum mainMenuOptions
    {   
        Settings = 0, StartListening = 1, StopListening = 3, ViewClients = 4
    }

    public enum settingsMenuOptions
    {
        SetIp = 0, SetPort = 1
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("Here are your menu options:");
        for(int i = 0; i<mainMenuList.Count; i++)
        {
            Console.WriteLine((i+1).ToString() + ". " + mainMenuOptionsAssignment[mainMenuList[i]]);
        }
        validateInput(Console.ReadLine(), "main");
    }

    public void ShowSettingsMenu()
    {
        Console.WriteLine("Here are your menu options:");
        for(int i = 0; i<settingsMenuList.Count; i++)
        {
            Console.WriteLine((i+1).ToString() + ". " + settingsMenuOptionsAssignment[settingsMenuList[i]]);
        }
        validateInput(Console.ReadLine(), "settings");
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

    public Task ListenForClients()
    {
        Task startListeningTask = Task.Run(()=> 
        {
        this.isListening = true;
        this.updateMainMenu();
        this.ShowMainMenu();
        });

        return startListeningTask;
    }

    public Task StopListeningForClients()
    {
        Task stopListeningTask = Task.Run(() =>
        {
            this.isListening = false;
            this.updateMainMenu();
            this.ShowMainMenu();
        });
        return stopListeningTask;
    }

    public void ViewClients()
    {
        Console.WriteLine("Clients here");
        this.ShowMainMenu();
    }

    public async void validateInput(string input, string menu)
    {
        int menuChoise = 0;
        if(input == "" || input == null)
        {
            Console.WriteLine("\r\n No input, try again: \r\n");
            validateInput(Console.ReadLine(), menu);
        }

        try
        {
            menuChoise = Convert.ToInt32(input);
        }
        catch
        {
            Console.WriteLine("\r\n Invalid input, try again: \r\n");
            validateInput(Console.ReadLine(), menu);
        }

        if(menu == "main")
        {
            if(menuChoise > 0 && menuChoise <= mainMenuList.Count)
            {
                switch(mainMenuList[menuChoise-1])
                {
                    case mainMenuOptions.Settings:
                    this.ShowSettingsMenu();
                    break;
                    case mainMenuOptions.StartListening:
                    await this.ListenForClients();
                    break;
                    case mainMenuOptions.StopListening:
                    await this.StopListeningForClients();
                    break;
                    case mainMenuOptions.ViewClients:
                    this.ViewClients();
                    break;

                }
            }
            
        }

    }

    /*public Task ListenForInput()
    {
        Task listenForInputTask = Task.Run(() => 
        {
            while(true)
            {
                if(Console.ReadLine() != null)
                {
                    Console.ReadLine();
                }
            }
        });

        return listenForInputTask;
    }

    public void ReturnOutput(string input)
    {

    }*/


}