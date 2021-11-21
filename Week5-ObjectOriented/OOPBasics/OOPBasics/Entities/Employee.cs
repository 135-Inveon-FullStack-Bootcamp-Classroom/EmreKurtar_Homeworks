using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBasics.Entities
{
    //Inheritance
    public class Employee : Person
    {
        public Employee(string name,string surname,int age,int salary):base(name,surname,age)
        {
            Salary = salary;
        }

        public int Salary { get; set; }
    }
}
