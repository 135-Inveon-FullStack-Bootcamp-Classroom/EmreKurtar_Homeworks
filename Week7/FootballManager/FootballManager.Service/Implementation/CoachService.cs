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
    public class CoachService : ICoachService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Coach> _repo;

        public CoachService(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
            _repo = _unitOfWork.GetRepository<Coach>();
        }

        public async Task AddAsync(Coach entity)
        {
            await _repo.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<Coach> Get(Expression<Func<Coach, bool>> predicate)
        {
            return _repo.Get(predicate);
        }

        public async Task<IEnumerable<Coach>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public void Remove(Coach entity)
        {
            _repo.Remove(entity);
            _unitOfWork.Commit();
        }

        public async Task<Coach> SingleOrDefaultAsync(Expression<Func<Coach, bool>> predicate)
        {
            return await _repo.SingleOrDefaultAsync(predicate);
        }

        public Coach Update(Coach entity)
        {
            _repo.Update(entity);
            _unitOfWork.Commit();
            return entity;

        }
    }
}
