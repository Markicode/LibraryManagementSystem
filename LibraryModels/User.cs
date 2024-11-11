using LibraryDatabase;
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

        public int? id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public User(string email, string password, string role) 
        {
            this.attributes = new string[] {"id", "email", "password", "role"};
            this.tableName = "user";
            this.email = email;
            this.password = password;
            this.role = role;
        }

        public User FindUser(string email)
        {
            User? user = null;
            int tempId = 0;
            string tempEmail = "";
            string tempPassword = "";
            string tempRole = "";

            List<object> results = new List<object>();
            results = dbConn.PerformQuery($"SELECT * FROM {this.tableName} WHERE email = \"{email}\"");
            if (results.Count > 0)
            {
                foreach (List<object> row in results)
                {
                    tempId = Convert.ToInt32(row[0]);
                    tempEmail = Convert.ToString(row[1]);
                    tempPassword = Convert.ToString(row[2]);
                    tempRole = Convert.ToString(row[3]);
                }
                user = new User(tempEmail, tempPassword, tempRole);
                user.id = tempId;
                return user;
            }

            return user;
        }

        public void UpdatePassword(int id, string hashedPassword)
        {
            dbConn.PerformNonQuery($"UPDATE user SET password = \"{hashedPassword}\" WHERE id = \"{id}\"");
        }

        public int CountUsers()
        {
            int userCount = 0;
            var results = dbConn.PerformQuery($"SELECT COUNT(*) FROM user");
            if (results.Count > 0)
            {
                foreach (List<object> row in results)
                {
                    userCount = Convert.ToInt32(row[0]);
                }
            }
            return userCount;
        }

        public List<object> GetAllUsers()
        {
            var results = new List<object>();
            results = dbConn.PerformQuery("SELECT * FROM user");
            return results;
        }
    }
}
