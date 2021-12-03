using FootballManager.Core.Interfaces.Repository;
using FootballManager.Core.Interfaces.UnitOfWork;
using FootballManager.Entities;
using FootballManager.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Service.Implementation
{
    public class FootballerService : IFootballerService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Footballer> _repo;

        public FootballerService(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
            _repo = _unitOfWork.GetRepository<Footballer>();
        }

        public async Task AddAsync(Footballer entity)
        {
             await _repo.AddAsync(entity);
        }

        public IQueryable<Footballer> Get(Expression<Func<Footballer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Footballer>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public void Remove(Footballer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Footballer> SingleOrDefaultAsync(Expression<Func<Footballer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Footballer Update(Footballer entity)
        {
            throw new NotImplementedException();
        }
    }
}
