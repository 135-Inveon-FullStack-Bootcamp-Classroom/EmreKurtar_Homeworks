using OOPBasics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBasics.Services
{
    public class EmployeeManager
    {
        public List<Employee> EmployeeS { get; set; }
        public EmployeeManager()
        {
            EmployeeS = new List<Employee>();
        }

        public Employee CreateEmployee(string name, string surname, int age, int salary)
        {
            Employee newEmployee = new Employee(name, surname, age, salary);
            EmployeeS.Add(newEmployee);
            return newEmployee;
        }
    }
}
