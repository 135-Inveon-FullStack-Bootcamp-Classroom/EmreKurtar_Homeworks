using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces.Repository;
using MovieApp.Core.Interfaces.UnitOfWork;
using MovieApp.Data.Repositories;
using MovieApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Implementations
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Actor> _repo;

        public ActorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repo = _unitOfWork.GetRepository<Actor>();
            
        }



        public void Add(Actor actor)
        {
            _repo.AddAsync(actor);
        }

        public void Delete(int id)
        {
            Actor foundActor = _repo.SingleOrDefaultAsync(x => x.ID == id).Result;
            if(foundActor != null)
            {
                _repo.Remove(foundActor);
            }
            else
            {
                throw new Exception("Silinmeye çalışılan kayıt bulunamadı");
            }
        }

        public List<Actor> GetAll()
        {
            return _repo.GetAllAsync().Result.ToList();
        }

        public List<Actor> GetAllWithMovies()
        {
            return _unitOfWork.actorRepository.GetAllWithMovies();
        }

        public void Update(Actor actor)
        {
            Actor foundActor = _repo.SingleOrDefaultAsync(x => x.ID == actor.ID).Result;
            if (foundActor != null)
            {
                _repo.Update(actor);
            }
            else
            {
                throw new Exception("Kayıt güncellenemedi");
            }
        }
    }
}
