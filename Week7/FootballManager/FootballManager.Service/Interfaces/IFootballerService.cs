using FootballManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Service.Interfaces
{
    public interface IFootballerService : IService
    {
        Task<IEnumerable<Footballer>> GetAllAsync();
        IQueryable<Footballer> Get(Expression<Func<Footballer, bool>> predicate);
        Task<Footballer> SingleOrDefaultAsync(Expression<Func<Footballer, bool>> predicate);
        Task AddAsync(Footballer entity);
        void Remove(Footballer entity);
        Footballer Update(Footballer entity);
    }
}
