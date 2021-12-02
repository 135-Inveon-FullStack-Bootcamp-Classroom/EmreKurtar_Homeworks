using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.DTO
{
    public class ActorDTO
    {
        public string ActorName { get; set; }
        public List<MovieDTO> Movies{ get; set; }
    }
}
