using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Entities
{
    public class Actor : BaseEntity
    {
        public string FullName { get; set; }
        public ICollection<Movie> Movies { get; set; }

    }
}
