using OOPBasics.Entities;
using OOPBasics.Services;
using System;

namespace OOPBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployerManager employerManager = new EmployerManager();
            EmployeeManager employeeManager = new EmployeeManager();

            Employee emp1 = employeeManager.CreateEmployee("Emre", "Kurtar", 30, 10000);
            Employee emp2 = employeeManager.CreateEmployee("Merve", "Kurtar", 25, 5000);
            employeeManager.CreateEmployee("Fatma", "Kurtar", 20, 8000);
            employeeManager.CreateEmployee("Can", "Kurtar", 19, 3000);

            Employer patron = employerManager.CreateEmployer("Patron", "Patron", 45, "Yazılım Uzmanı");

            employerManager.ChangeEmployeeSalary(employeeManager.EmployeeS, "Emre", 5000);
            employerManager.ChangeEmployeeSalary(employeeManager.EmployeeS, "Merve","Kurtar", 1000);

            Console.WriteLine(emp1.Salary);
            Console.WriteLine(emp2.Salary);

        }
    }
}
