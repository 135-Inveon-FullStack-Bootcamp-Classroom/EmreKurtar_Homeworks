using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data.Repositories
{
    public class ActorRepository : Repository<Actor>, IActorRepository
    {
        public ActorRepository(DbContext context):base(context)
        {

        }

        public List<Actor> GetAllWithMovies()
        {
            return _context.Set<Actor>().Include(x => x.Movies).ToList();
        }
    }
}
