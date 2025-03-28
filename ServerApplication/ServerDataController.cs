using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Database;
using System.Text.Json;

namespace ServerApplication
{
    public class ServerDataController
    {
        private User defaultUser;

        public ServerDataController() 
        {
            this.defaultUser = new User();
        }

        public string GetUser(string email)
        {
            User? user = defaultUser.FindUser(email);
            return SerializeObject(user);
        }

        public string GetAllNews()
        {
            NewsMessage news = new NewsMessage();
            List<NewsMessage> newsList = news.GetAllEntries<NewsMessage>();
            Console.WriteLine(SerializeObject(newsList));
            return SerializeObject(newsList);
        }
        
        public string GetQueryResultMultiple<T>(T model) where T : Model, new()
        {
            List<T> results = new List<T>();
            results = model.GetAllEntries<T>();

            return SerializeObject(results);
        }

        public string SerializeObject(object o)
        {
            string jsonString = JsonSerializer.Serialize(o);
            return jsonString;
        }
    }
}
