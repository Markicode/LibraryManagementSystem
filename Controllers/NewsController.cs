using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public class NewsController
    {
        public NewsController() { }

        public List<NewsMessage> GetAllNews()
        {
            List<object> results = new List<object>();
            List<NewsMessage> messages = new List<NewsMessage>();

            NewsMessage message = new NewsMessage("empty", "message", "no picture", "no target");
            results = message.GetAllEntries();
            if (results.Count > 0)
            {
                foreach (List<object> row in results)
                {
                    messages.Add(new NewsMessage(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString()));
                }
            }
            return messages;
        }
    }
}
