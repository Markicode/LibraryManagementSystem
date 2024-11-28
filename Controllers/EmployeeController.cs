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

        public void addEmployee(Employee employee, User user)
        {
            activeEmployee.AddEmployee(employee, user);
        }

        public List<Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees = activeEmployee.GetAllEmployees();
            return employees;
        }
    }
}
