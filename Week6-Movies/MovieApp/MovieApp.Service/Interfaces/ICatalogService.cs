using MovieApp.Core.Entities;
using MovieApp.Service.DTO;
using System.Collections.Generic;

namespace MovieApp.Service.Interfaces
{
    public interface ICatalogService : IService
    {
        Movie GetMovieById(int id);

        List<ActorDTO> GetAllActorsWithMovies();
    }
}
