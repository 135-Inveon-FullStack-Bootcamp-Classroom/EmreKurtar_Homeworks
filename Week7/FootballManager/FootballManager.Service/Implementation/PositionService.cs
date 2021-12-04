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
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Position> _repo;

        public PositionService(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
            _repo = _unitOfWork.GetRepository<Position>();
        }

        public async Task AddAsync(Position entity)
        {
            await _repo.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<Position> Get(Expression<Func<Position, bool>> predicate)
        {
            return _repo.Get(predicate);
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public void Remove(Position entity)
        {
            _repo.Remove(entity);
            _unitOfWork.Commit();
        }

        public async Task<Position> SingleOrDefaultAsync(Expression<Func<Position, bool>> predicate)
        {
            return await _repo.SingleOrDefaultAsync(predicate);
        }

        public Position Update(Position entity)
        {
            _repo.Update(entity);
            _unitOfWork.Commit();
            return entity;

        }
    }
}
