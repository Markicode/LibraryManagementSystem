namespace LibraryDatabase
{
    using MySql.Data;
    using MySql.Data.MySqlClient;
    using System.Data.Common;

    public class DbConnection
    {
        public string server { get; set; }
        public string databaseName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public MySqlConnection? connection { get; set; }

        public DbConnection(string server, string databaseName, string userName, string password)
        {
            this.server = server;
            this.databaseName = databaseName;
            this.userName = userName;
            this.password = password;
        }

        /*private static DbConnection _instance = null;
        public static DbConnection Instance()
        {
            if (_instance == null)
                _instance = new DbConnection();
            return _instance;
        }*/

        public bool Open()
        {
            if (connection == null)
            {
                if (String.IsNullOrEmpty(this.databaseName))
                    return false;
                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", server, databaseName, userName, password);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
