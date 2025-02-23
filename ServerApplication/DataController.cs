using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Database;

namespace ServerApplication
{
    public class DataController
    {
        private User defaultUser;

        public DataController() 
        {
            this.defaultUser = new User("default@lms.nl", "12345678", "default");
        }

        public bool CheckForUser(string email)
        {
            bool userPresent = false;
            if (defaultUser.FindUser(email) != null)
            {
                userPresent = true;
            }
            return userPresent;
        }

        /*public List<T> GetQueryResultMultiple<T>(T model) where T : Model
        {
            List<object> results = new List<object>();

            results = model.GetAllEntries();
            if (results.Count > 0)
            {
                foreach (List<object> row in results)
                {
                    messages.Add(new NewsMessage(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString()));
                }
            }
            return messages;
        }*/
    }
}
