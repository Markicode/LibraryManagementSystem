using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Models
{
    public class Employee : Person
    {
        public override string tableName { get ; set; }
        public override string[] attributes { get; set; }

        public int id { get; set; }
        public int userId { get; set; }
        public string bsn { get; set; }
        public double salary { get; set; }

        public Employee(int id, int personId, string firstName, string lastName, DateTime birthDate, int userId, string bsn, double salary) 
        {
            this.id = id;
            this.personId = personId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.userId = userId;
            this.bsn = bsn;
            this.salary = salary;

            this.tableName = "employee";
            this.attributes = new string[] { "id", "user_id", "person_id", "bsn", "salary" };
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            List<object> results = new List<object>();
            results = dbConn.PerformQuery(
                $"SELECT employee.id, person.id, person.first_name, person.last_name, person.birth_date, employee.user_id, employee.bsn, employee.salary " +
                $"FROM employee " +
                $"JOIN person ON employee.person_id = person.id " +
                $"JOIN user ON employee.user_id = user.id " +
                $"WHERE user.role = \"employee\"");

            if (results.Count > 0)
            {
                foreach (List<object> row in results)
                {
                    Employee employee = new Employee(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), row[2].ToString(), row[3].ToString(), Convert.ToDateTime(row[4]),
                        Convert.ToInt32(row[5]), row[6].ToString(), Convert.ToDouble(row[7]));
                    employees.Add(employee);
                }
            }
            else
            {
                throw new Exception();
            }
            return employees;
        }

        public bool AddEmployee(Employee employee, User user)
        {
            using(dbConn.connection = new MySqlConnection(dbConn.connString))
            {
                dbConn.connection.Open();
                MySqlCommand cmd = dbConn.connection.CreateCommand();
                MySqlTransaction transaction = dbConn.connection.BeginTransaction();
                cmd.Connection = dbConn.connection;
                cmd.Transaction = transaction;

                try
                {
                    cmd.CommandText =
                        $"Insert into user (email, password, role) VALUES (\"{user.email}\", \"{user.password}\", \"{user.role}\")";
                    cmd.ExecuteNonQuery();
                    int userId = Convert.ToInt32(cmd.LastInsertedId);
                    cmd.CommandText =
                        $"Insert into person (first_name, last_name, birth_date) VALUES (\"{employee.firstName}\", \"{employee.lastName}\", STR_TO_DATE(\"{employee.birthDate}\", '%d-%m-%Y %H:%i:%s'))";
                    cmd.ExecuteNonQuery();
                    int personId = Convert.ToInt32(cmd.LastInsertedId);

                    cmd.CommandText =
                        $"Insert into employee (user_id, person_id, bsn, salary) VALUES (\"{userId.ToString()}\", \"{personId.ToString()}\", \"{employee.bsn}\", \"{employee.salary}\")";
                    cmd.ExecuteNonQuery();

                    // Attempt to commit the transaction.
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                        return false;
                    }
                    return false;
                }
            }

        }
    }
}
