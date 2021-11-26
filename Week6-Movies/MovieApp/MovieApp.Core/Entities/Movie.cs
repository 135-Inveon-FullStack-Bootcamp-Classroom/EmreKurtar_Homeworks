using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Entities
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public Director Director { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
