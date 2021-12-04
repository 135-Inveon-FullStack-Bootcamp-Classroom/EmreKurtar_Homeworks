using FootballManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Service.Interfaces
{
    public interface IManagerService : IService
    {
        Task<IEnumerable<Manager>> GetAllAsync();
        IQueryable<Manager> Get(Expression<Func<Manager, bool>> predicate);
        Task<Manager> SingleOrDefaultAsync(Expression<Func<Manager, bool>> predicate);

        Task AddAsync(Manager entity);
        void Remove(Manager entity);
        Manager Update(Manager entity);
    }
}
