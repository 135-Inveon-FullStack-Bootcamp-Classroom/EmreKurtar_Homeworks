using FootballManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Service.Interfaces
{
    public interface ICoachService : IService
    {
        Task<IEnumerable<Coach>> GetAllAsync();
        IQueryable<Coach> Get(Expression<Func<Coach, bool>> predicate);
        Task<Coach> SingleOrDefaultAsync(Expression<Func<Coach, bool>> predicate);

        Task AddAsync(Coach entity);
        void Remove(Coach entity);
        Coach Update(Coach entity);
    }
}
