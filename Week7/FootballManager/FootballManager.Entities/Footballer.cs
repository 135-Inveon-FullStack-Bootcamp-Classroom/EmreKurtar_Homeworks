using FootballManager.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Entities
{
    public class Footballer : Person
    {
        public ICollection<Position> Positions { get; set; }
        public Team Team { get; set; }
        public NationalTeam NationalTeam { get; set; }


    }
}
