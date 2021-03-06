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
             await _unitOfWork.CommitAsync();
        }

        public IQueryable<Footballer> Get(Expression<Func<Footballer, bool>> predicate)
        {
            return _repo.Get(predicate);
        }

        public async Task<IEnumerable<Footballer>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public void Remove(Footballer entity)
        {
            _repo.Remove(entity);
            _unitOfWork.Commit();
        }

        public async Task<Footballer> SingleOrDefaultAsync(Expression<Func<Footballer, bool>> predicate)
        {
            return await _repo.SingleOrDefaultAsync(predicate);
        }

        public Footballer Update(Footballer entity)
        {
            _repo.Update(entity);
            _unitOfWork.Commit();
            return entity;

        }
    }
}
