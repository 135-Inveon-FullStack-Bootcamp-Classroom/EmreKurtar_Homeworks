using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBasics.Entities
{
    public class Person
    {
        private int _Age;
        //Encapsulation 
        public int Age
        {
            get { return _Age; }
            set
            {
                if (value < 18)
                {
                    _Age = 0;
                }
                else
                {
                    _Age = value;
                }
            }
        }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person(string name,string surname,int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        
    }
}
