using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces.Service
{
    public interface IActorService : IService<Actor>
    {
        // I've created this service from generic service interface
        //      because here we can handle some business operation
        //      like AscendingOrder(Movie movie) function. Get the actors from movie parameter
        //      and list ascending order actors belongs to the movie
    }
}
