using FootballManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Service.Interfaces
{
    public interface IPositionService : IService
    {
        Task<IEnumerable<Position>> GetAllAsync();
        IQueryable<Position> Get(Expression<Func<Position, bool>> predicate);
        Task<Position> SingleOrDefaultAsync(Expression<Func<Position, bool>> predicate);

        Task AddAsync(Position entity);
        void Remove(Position entity);
        Position Update(Position entity);
    }
}
