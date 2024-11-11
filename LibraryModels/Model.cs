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
        protected DbConn dbConn;
        public abstract string tableName { get; set; }
        public abstract string[] attributes { get; set; }

        protected Model() 
        { 
            this.dbConn = new DbConn("localhost", "test", "mark", "FakePassword");
        }

        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        public void Add(Model model)
        {
            string statement = "INSERT INTO " + this.tableName + " (";
            foreach (string attribute in attributes)
            {
                if (attribute != "id") 
                {
                    statement += attribute + ", ";
                }
            }
            statement = statement.Remove(statement.Length - 2);
            statement += ") VALUES (";
            foreach (string attribute in attributes)
            {
                // TODO: Implement possibilty of empty attributes.
                if (attribute != "id")
                { 
                statement += "\"" + model[attribute].ToString() + "\", ";
                }
            }
            statement = statement.Remove(statement.Length - 2);
            statement += ")";

            if (this.dbConn != null)
            {
                dbConn.PerformNonQuery(statement);
            }
        }

        public List<object> GetAllEntries()
        {
            List<object> result = new List<object>();
            string query = "SELECT * FROM " + this.tableName + "";
            if (this.dbConn != null)
            {
                result =  dbConn.PerformQuery(query);
            }
            return result;
        }

        public void Delete(int id)
        {

        }

        public void Update()
        {
            
        }

        public List<object> GetSingleEntry(int id)
        {
            List<object> result = new List<object>();
            string query = "SELECT * FROM " + this.tableName + " WHERE id = \"" + id + "\"";
            if (this.dbConn != null)
            {
                result = dbConn.PerformQuery(query);
            }
            return result;
        }

    }
}
