using LibraryDatabase;
using LibraryModels;
using MySqlX.XDevAPI;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Controllers
{
    public class LoginController
    {
        private Book book;

        public LoginController() 
        {
            book = new Book();
        }

        public string ReadFromDatabase()
        {
            string output = "";
            List<object> results = book.Read();

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

        public void AddToDatabase()
        {
            book.Add();
        }
        
    }
}
