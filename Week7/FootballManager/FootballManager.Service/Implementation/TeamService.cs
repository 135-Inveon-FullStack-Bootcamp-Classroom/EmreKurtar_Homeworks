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
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Team> _repo;

        public TeamService(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
            _repo = _unitOfWork.GetRepository<Team>();
        }

        public async Task AddAsync(Team entity)
        {
            await _repo.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<Team> Get(Expression<Func<Team, bool>> predicate)
        {
            return _repo.Get(predicate);
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public void Remove(Team entity)
        {
            _repo.Remove(entity);
            _unitOfWork.Commit();
        }

        public async Task<Team> SingleOrDefaultAsync(Expression<Func<Team, bool>> predicate)
        {
            return await _repo.SingleOrDefaultAsync(predicate);
        }

        public Team Update(Team entity)
        {
            _repo.Update(entity);
            _unitOfWork.Commit();
            return entity;

        }
    }
}
