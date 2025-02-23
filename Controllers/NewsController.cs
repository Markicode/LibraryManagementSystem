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
            List<NewsMessage> results = new List<NewsMessage>();
            List<NewsMessage> messages = new List<NewsMessage>();

            NewsMessage message = new NewsMessage();
            results = message.GetAllEntries(message);
            /*if (results.Count > 0)
            {
                foreach (List<object> row in results)
                {
                    messages.Add(new NewsMessage(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString()));
                }
            }
            return messages;*/
            return results;
        }
    }
}
