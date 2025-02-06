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
            {settingsMenuOptions.SetPort, "Change the server port."},
            {settingsMenuOptions.Exit, "Exit to main menu."}
        };

        mainMenuList = new List<mainMenuOptions> {mainMenuOptions.Settings, mainMenuOptions.StartListening, mainMenuOptions.ViewClients};
        settingsMenuList = new List<settingsMenuOptions> {settingsMenuOptions.SetIp, settingsMenuOptions.SetPort, settingsMenuOptions.Exit};
    } 
    public enum mainMenuOptions
    {   
        Settings = 0, StartListening = 1, StopListening = 3, ViewClients = 4
    }

    public enum settingsMenuOptions
    {
        SetIp = 0, SetPort = 1, Exit = 3
    }

    public void ShowMainMenu()
    {
        Dictionary<int, mainMenuOptions> mainMenu = this.MakeDictionary(mainMenuList);
        Console.WriteLine("Main menu options:");
        foreach(KeyValuePair<int, mainMenuOptions> mainOption in mainMenu)
        {
            string choiseText = string.Format("{0}. {1, -5}", mainOption.Key, mainOption.Value.ToString());
            Console.WriteLine(choiseText);
        }
        int mainChoise = ValidateMenuChoise(mainMenuList.Count);
        mainMenuOptions chosenOption = mainMenu[mainChoise];
        switch (chosenOption)
        {
            case mainMenuOptions.StartListening:
                {
                    this.isListening = true;
                    Console.WriteLine("Started listening. \r\n");
                    this.updateMainMenu();
                    this.ShowMainMenu();
                    break;
                }
            case mainMenuOptions.StopListening:
                {
                    this.isListening = false;
                    Console.WriteLine("Stopped listening. \r\n");
                    this.updateMainMenu();
                    this.ShowMainMenu();
                    break;
                }
            case mainMenuOptions.Settings:
                {
                    this.ShowSettingsMenu();
                    break;
                }
            case mainMenuOptions.ViewClients:
                {
                    this.ViewClients();
                    break;
                }
        }

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
        int settingChoise = ValidateMenuChoise(settingsMenuList.Count);
        settingsMenuOptions chosenOption = settingsMenu[settingChoise];
        switch (chosenOption)
        {
            case settingsMenuOptions.SetIp:
                {
                    Console.WriteLine("Set IP here \r\n");
                    this.ShowSettingsMenu();
                    break;
                }
            case settingsMenuOptions.SetPort:
                {
                    Console.WriteLine("Set Port here \r\n");
                    this.ShowSettingsMenu();
                    break;
                }
            case settingsMenuOptions.Exit:
                {
                    Console.WriteLine("Exiting to main menu. \r\n");
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