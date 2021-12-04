using FootballManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Service.Interfaces
{
    public interface ITacticService : IService
    {
        Task<IEnumerable<Tactic>> GetAllAsync();
        IQueryable<Tactic> Get(Expression<Func<Tactic, bool>> predicate);
        Task<Tactic> SingleOrDefaultAsync(Expression<Func<Tactic, bool>> predicate);

        Task AddAsync(Tactic entity);
        void Remove(Tactic entity);
        Tactic Update(Tactic entity);
    }
}
