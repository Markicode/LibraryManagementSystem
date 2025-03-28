using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalApplicationVariables
{
    public static class Enumeration
    {
        public enum CommGoal
        {
            ServerConnect = 0, Login = 1, CredentialsCheck = 2, SendData = 3, Unknown = 4
        }

        public enum QueryCommands
        {
            GetAllNews = 0, Unknown = 1
        }
    }
}
