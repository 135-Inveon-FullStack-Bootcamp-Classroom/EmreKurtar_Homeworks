using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBasics.Entities
{
    // Polymorphism with Person class 
    // Inheritance
    public class Employer : Person
    {
        public Employer(string name, string surname, int age,string degree) : base(name, surname, age)
        {
            Degree = degree;
        }

        public string Degree { get; set; }
    }
}
