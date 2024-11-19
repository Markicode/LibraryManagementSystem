﻿using LibraryDatabase;
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

        public User(int id, string email, string password, string role)
        {
            this.attributes = new string[] { "id", "email", "password", "role" };
            this.tableName = "user";
            this.id = id;
            this.email = email;
            this.password = password;
            this.role = role;
        }

        // Find single user in database, returns object of User class.
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

        // Count number of users in database.
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

        // Retrieve all user data and create List of User objects.
        public List<User> GetAllUsers()
        {
            var results = new List<object>();
            List<User> users = new List<User>();
            results = dbConn.PerformQuery("SELECT * FROM user");
            if (results.Count > 0)
            {
                foreach (List<object> row in results)
                {
                    users.Add(new User(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), row[3].ToString()));
                }
            }
            return users;
        }
    }
}
