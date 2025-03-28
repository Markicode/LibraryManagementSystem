using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalApplicationVariables;
using System.Threading.Tasks.Dataflow;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Controllers
{
    public class ClientDataController
    {
        private ConnectionController connectionController;

        public ClientDataController(ConnectionController connectionController)
        {
            this.connectionController = connectionController;
        }

        public async Task<List<NewsMessage>> GetAllNewsMessages()
        {
            connectionController.SendMessageToServer(Enumeration.QueryCommands.GetAllNews.ToString(), Enumeration.CommGoal.SendData);
            connectionController.manualResetDataSentEvent.WaitOne();
            
            string result = await connectionController.bufferBlock.ReceiveAsync();
            List<NewsMessage> newslist = JsonSerializer.Deserialize<List<NewsMessage>>(result);
            return newslist;
        }


    }
}
