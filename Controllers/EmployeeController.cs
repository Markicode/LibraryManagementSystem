using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public class EmployeeController
    {
        public User user;
        public Employee activeEmployee;

        public EmployeeController(User user) 
        {
            this.user = user;
            this.activeEmployee = user.GetEmployee(user);
        }

        public Employee addEmployee()
        {
            Employee? employee = null;
            return employee;
        }
    }
}
