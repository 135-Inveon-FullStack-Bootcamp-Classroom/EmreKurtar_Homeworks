using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces.UnitOfWork;
using MovieApp.Service.DTO;
using MovieApp.Service.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MovieApp.Service.Implementations
{
    public class CatalogService : ICatalogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CatalogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ActorDTO> GetAllActorsWithMovies()
        {
            
            var actorRepo = _unitOfWork.GetRepository<Actor>();
            var actors = actorRepo.Get(x => 1 == 1).Include(x => x.Movies).Select(x => new ActorDTO { ActorName = x.FullName, Movies = x.Movies.Select(m => new MovieDTO { MovieName = m.Name }).ToList() }).ToList();
            return actors;
        }

        public Movie GetMovieById(int id)
        {
            var movieRepo = _unitOfWork.GetRepository<Movie>();
            var data = movieRepo.GetByIdAsync(id).Result;
            
            return data;
        }

        

        
    }
}
