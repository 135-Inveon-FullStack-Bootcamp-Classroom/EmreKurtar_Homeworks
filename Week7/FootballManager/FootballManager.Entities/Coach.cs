using FootballManager.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Entities
{
    public class Coach : Person
    {
        public ICollection<Tactic> Tactics { get; set; }
        public Team Team { get; set; }

    }
}
