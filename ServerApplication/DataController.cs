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
    }
}
