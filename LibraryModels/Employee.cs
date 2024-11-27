using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
