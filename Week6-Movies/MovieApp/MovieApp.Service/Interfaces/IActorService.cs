using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Interfaces
{
    public interface IActorService : IService
    {
        void Add(Actor actor);
        void Update(Actor actor);
        void Delete(int id);
        List<Actor> GetAll();
        List<Actor> GetAllWithMovies();

        
    }
}
