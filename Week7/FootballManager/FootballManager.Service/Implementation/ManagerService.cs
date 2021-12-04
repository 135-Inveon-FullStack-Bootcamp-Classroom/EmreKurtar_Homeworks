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
    public class ManagerService : IManagerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Manager> _repo;

        public ManagerService(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
            _repo = _unitOfWork.GetRepository<Manager>();
        }

        public async Task AddAsync(Manager entity)
        {
            await _repo.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<Manager> Get(Expression<Func<Manager, bool>> predicate)
        {
            return _repo.Get(predicate);
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public void Remove(Manager entity)
        {
            _repo.Remove(entity);
            _unitOfWork.Commit();
        }

        public async Task<Manager> SingleOrDefaultAsync(Expression<Func<Manager, bool>> predicate)
        {
            return await _repo.SingleOrDefaultAsync(predicate);
        }

        public Manager Update(Manager entity)
        {
            _repo.Update(entity);
            _unitOfWork.Commit();
            return entity;

        }
    }
}
