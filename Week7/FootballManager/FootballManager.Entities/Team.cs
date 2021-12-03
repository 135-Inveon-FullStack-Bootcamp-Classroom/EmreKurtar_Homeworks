using FootballManager.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public int FoundingYear { get; set; }
        public ICollection<Footballer> Footballers { get; set; }
        public int CoachId { get; set; }

        public Coach Coach { get; set; }
    }
}
