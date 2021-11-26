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
        
        public ActorRepository(MovieDBContext context) : base(context)
        {

        }

       
    }
}
