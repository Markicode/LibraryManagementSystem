using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Models
{
    public abstract class Model
    {
        protected DbConn dbConn;
        public abstract string tableName { get; set; }
        public abstract string[] attributes { get; set; }
        public abstract Dictionary<string, string> attributeTypes { get; set; }

        protected Model() 
        { 
            this.dbConn = new DbConn("localhost", "lms_woordenschat", "mark", "FakePassword");
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

        // TODO: Create query function with limited return values
        public List<T> GetAllEntries<T>() where T : Model, new()
        {
            List<object> results = new List<object>();
            List<T> resultsList = new List<T>();

            string query = "SELECT * FROM " + this.tableName + "";
            int numberOfAttributes = 0;
            if (this.dbConn != null)
            {
                (numberOfAttributes, results) =  dbConn.PerformQuery(query);
            }
            foreach (List<object> result in results)
            {
                T newObject = Activator.CreateInstance<T>();
                for (int i = 0; i < numberOfAttributes; i++)
                {
                    string attributeType = this.attributeTypes[this.attributes[i]];
                    switch(attributeType)
                    {
                        case "int":
                            newObject[this.attributes[i]] = result[i];
                            break;
                        case "string":
                            newObject[this.attributes[i]] = result[i].ToString();
                            break;
                    }
                }
                resultsList.Add( newObject );
            }
            
            return resultsList;
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
            int numberOfAttributes = 0;
            if (this.dbConn != null)
            {
                (numberOfAttributes, result) = dbConn.PerformQuery(query);
            }
            return result;
        }

        // TODO: create dummy function to inform about parameterless constructor for derived classes
    }
}
