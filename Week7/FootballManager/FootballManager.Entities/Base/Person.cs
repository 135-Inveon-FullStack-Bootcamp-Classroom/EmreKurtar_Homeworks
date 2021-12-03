using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Entities.Base
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
