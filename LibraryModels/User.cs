using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class User : Model
    {
        public override string[] attributes { get; set; }
        public override string tableName { get; set; }

        public string email { get; set; }
        public string password { get; set; }

        public User(string email, string password) 
        {
            this.attributes = new string[] { "email", "password" };
            this.tableName = "user";
            this.email = email;
            this.password = password;
        }
    }
}
