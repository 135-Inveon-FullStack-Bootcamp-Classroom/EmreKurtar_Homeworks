using FootballManager.Core.Interfaces.Repository;
using FootballManager.Data.Context;
using FootballManager.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Data.Repository
{
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : BaseEntity
    {
        protected readonly FootballDbContext _context;
        private readonly DbSet<Tentity> _dbset;

        public Repository(FootballDbContext dbcontext )
        {
            _context = dbcontext;
            _dbset = dbcontext.Set<Tentity>();
        }

        public async Task AddAsync(Tentity entity)
        {
            await _dbset.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Tentity> entities)
        {
            await _dbset.AddRangeAsync(entities);
        }

        public IQueryable<Tentity> Get(Expression<Func<Tentity, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Remove(Tentity entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Tentity> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public async Task<Tentity> SingleOrDefaultAsync(Expression<Func<Tentity, bool>> predicate)
        {
            return await _dbset.Where(predicate).SingleOrDefaultAsync();
        }

        public Tentity Update(Tentity entity)
        {
            _context.Entry<Tentity>(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
