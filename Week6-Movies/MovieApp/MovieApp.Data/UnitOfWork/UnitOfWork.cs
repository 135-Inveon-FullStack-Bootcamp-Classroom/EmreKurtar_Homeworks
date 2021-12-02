using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces.Repository;
using MovieApp.Core.Interfaces.UnitOfWork;
using MovieApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDBContext _context;
        private ActorRepository _actorRepo;
        public IActorRepository actorRepository => _actorRepo = _actorRepo ?? new ActorRepository(_context);


        private Dictionary<Type, object> Repositories = new Dictionary<Type, object>();
        public UnitOfWork(MovieDBContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            Repository<T> repository;
            var found = Repositories.TryGetValue(typeof(T), out object repositoryObject);
            if (!found)
            {
                repository = new Repository<T>(_context);
                Repositories.Add(typeof(T), repository);
            }
            else
            {
                repository = (Repository<T>)repositoryObject;
            }
            return repository;
        }
    }
}
