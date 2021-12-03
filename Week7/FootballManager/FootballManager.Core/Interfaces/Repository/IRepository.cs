using FootballManager.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FootballManager.Core.Interfaces.Repository
{
    public interface IRepository<Tentity> where Tentity: BaseEntity
    {
        Task<Tentity> GetByIdAsync(int id);
        Task<IEnumerable<Tentity>> GetAllAsync();
        IQueryable<Tentity> Get(Expression<Func<Tentity, bool>> predicate);
        Task<Tentity> SingleOrDefaultAsync(Expression<Func<Tentity, bool>> predicate);

        Task AddAsync(Tentity entity);
        Task AddRangeAsync(IEnumerable<Tentity> entities);

        void Remove(Tentity entity);
        void RemoveRange(IEnumerable<Tentity> entities);
        Tentity Update(Tentity entity);
    }
}
