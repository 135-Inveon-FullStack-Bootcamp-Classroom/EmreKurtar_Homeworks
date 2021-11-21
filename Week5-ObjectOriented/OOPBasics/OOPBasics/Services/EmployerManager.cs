using OOPBasics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBasics.Services
{
    public class EmployerManager
    {
        public List<Employer> Employers { get; set; }
        public EmployerManager()
        {
            Employers = new List<Employer>();
        }

        public Employer CreateEmployer(string name,string surname,int age,string degree)
        {
            Employer newEmployer = new Employer(name, surname, age, degree);
            Employers.Add(newEmployer);
            return newEmployer;
        }

        public void ChangeEmployeeSalary(List<Employee> employeeList,string name,int newSalary)
        {
            if(employeeList != null)
            {
                foreach (var item in employeeList)
                {
                    if (item.Name.Equals(name))
                    {
                        item.Salary = newSalary;
                        Console.WriteLine(name + " 'nin maaşı " + item.Salary + " olarak değişti");
                    }
                }
            }
        }

        // Polymorphism with overriding function
        public void ChangeEmployeeSalary(List<Employee> employeeList, string name,string surname, int newSalary)
        {
            if (employeeList != null)
            {
                foreach (var item in employeeList)
                {
                    if (item.Name.Equals(name) && item.Surname.Equals(surname))
                    {
                        item.Salary = newSalary;
                        Console.WriteLine(name + " 'nin maaşı " + item.Salary + " olarak değişti");
                    }
                }
            }
        }


    }
}
