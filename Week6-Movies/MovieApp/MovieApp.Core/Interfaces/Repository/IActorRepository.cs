using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces.Repository
{
    public interface IActorRepository : IRepository<Actor>
    {
        List<Actor> GetAllWithMovies();
    }
}
