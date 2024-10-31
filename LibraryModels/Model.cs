using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDatabase;

namespace LibraryModels
{
    public abstract class Model
    {
        protected DbConn? dbConn;
        abstract protected string[] attributes { get; set; }

        protected Model() 
        { 
            this.dbConn = new DbConn("localhost", "test", "mark", "FakePassword");
        }

        public void Add()
        {
            if (this.dbConn != null)
            {
                dbConn.PerformNonQuery($"INSERT INTO user (email, password) VALUES (\"mark@test.nl\", \"12345678\"),(\"nogeenemail@mail.nl\", \"12345678\");");
            }
        }

        public List<object> Read()
        {
            List<object> result = new List<object>();
            if (this.dbConn != null)
            {
                result =  dbConn.PerformQuery("SELECT * FROM user");
            }
            return result;
        }

    }
}
