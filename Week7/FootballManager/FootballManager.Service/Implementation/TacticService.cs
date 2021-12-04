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
    public class TacticService : ITacticService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Tactic> _repo;

        public TacticService(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
            _repo = _unitOfWork.GetRepository<Tactic>();
        }

        public async Task AddAsync(Tactic entity)
        {
            await _repo.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<Tactic> Get(Expression<Func<Tactic, bool>> predicate)
        {
            return _repo.Get(predicate);
        }

        public async Task<IEnumerable<Tactic>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public void Remove(Tactic entity)
        {
            _repo.Remove(entity);
            _unitOfWork.Commit();
        }

        public async Task<Tactic> SingleOrDefaultAsync(Expression<Func<Tactic, bool>> predicate)
        {
            return await _repo.SingleOrDefaultAsync(predicate);
        }

        public Tactic Update(Tactic entity)
        {
            _repo.Update(entity);
            _unitOfWork.Commit();
            return entity;

        }
    }
}
