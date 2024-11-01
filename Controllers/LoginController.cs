using LibraryDatabase;
using LibraryModels;
using MySqlX.XDevAPI;
using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;

namespace Controllers
{
    public class LoginController
    {
        private User user;

        public LoginController() 
        {
            this.user = new User("mark@test.nl", "12345678");
        }

        public string ReadFromDatabase()
        {
            string output = "";
            List<object> results = user.GetAllEntries();

            if (results.Count > 0)
            {
                foreach (var result in results)
                {
                    List<object> row = result as List<object>;
                    foreach (var item in row)
                    {
                        output += item.ToString();
                    }
                }
            }
            return output;
        }

        public void AddUserToDatabase(string email, string password)
        {
            User newUser = new User(email, password);
            user.Add(newUser);
        }
        
    }
}
