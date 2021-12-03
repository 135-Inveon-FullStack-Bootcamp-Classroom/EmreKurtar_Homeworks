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
    public class FootballerService : IFootballerService
    {

        private readonly IUnitOfWork _unitOfWork;

        public FootballerService(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public Task AddAsync(Footballer entity)
        {
            IRepository<Footballer> repo = _unitOfWork.GetRepository<Footballer>();
            repo.AddAsync(entity);
        }

        public IQueryable<Footballer> Get(Expression<Func<Footballer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Footballer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(Footballer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Footballer> SingleOrDefaultAsync(Expression<Func<Footballer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Footballer Update(Footballer entity)
        {
            throw new NotImplementedException();
        }
    }
}
