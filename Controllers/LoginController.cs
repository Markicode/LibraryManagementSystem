using LibraryDatabase;
using MySqlX.XDevAPI;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Controllers
{
    public class LoginController
    {
        private DbConnection DbConn;

        public LoginController() 
        {
            DbConn = new DbConnection("localhost", "test", "mark", "FakePassword");
        }

        public string ReadFromDatabase()
        {
            string output = "";

            if (DbConn.Open())
            {
                string query = "SELECT * FROM user";
                var cmd = new MySqlCommand(query, DbConn.connection);
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    output += reader.GetInt32(0).ToString();
                    output += reader.GetString(1);
                    output += reader.GetString(2);
                }
            }
            return output;
        }
        
        
    }
}
