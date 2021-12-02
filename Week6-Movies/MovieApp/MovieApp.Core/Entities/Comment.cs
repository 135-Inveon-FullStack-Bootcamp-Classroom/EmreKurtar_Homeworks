using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public Movie Movie { get; set; }

    }
}
