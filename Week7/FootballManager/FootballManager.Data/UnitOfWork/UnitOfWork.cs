using FootballManager.Core.Interfaces.Repository;
using FootballManager.Core.Interfaces.UnitOfWork;
using FootballManager.Data.Context;
using FootballManager.Data.Repository;
using FootballManager.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FootballDbContext _context;
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(FootballDbContext context)
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

        public IRepository<Tentity> GetRepository<Tentity>() where Tentity : BaseEntity
        {
            Repository<Tentity> repository;
            bool isFound = _repositories.TryGetValue(typeof(Tentity), out object repositoryObject);
            
            if (!isFound)
            {
                Repository<Tentity> newrepository = new Repository<Tentity>(_context);
                _repositories.Add(typeof(Tentity), newrepository);
                return newrepository;
            }
            else
            {
                repository = (Repository<Tentity>)repositoryObject;
                return repository;
                
            }
        }
    }
}
