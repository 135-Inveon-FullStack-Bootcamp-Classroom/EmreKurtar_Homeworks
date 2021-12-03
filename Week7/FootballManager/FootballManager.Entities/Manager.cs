using FootballManager.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Entities
{
    public class Manager : Person
    {
        public ManagementPosition ManagementPosition { get; set; }
        public ICollection<Footballer> Footballers { get; set; }

    }
}
