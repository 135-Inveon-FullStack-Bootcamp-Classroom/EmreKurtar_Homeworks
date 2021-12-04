using FootballManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Service.Interfaces
{
    public interface ITeamService : IService
    {
        Task<IEnumerable<Team>> GetAllAsync();
        IQueryable<Team> Get(Expression<Func<Team, bool>> predicate);
        Task<Team> SingleOrDefaultAsync(Expression<Func<Team, bool>> predicate);

        Task AddAsync(Team entity);
        void Remove(Team entity);
        Team Update(Team entity);
    }
}
