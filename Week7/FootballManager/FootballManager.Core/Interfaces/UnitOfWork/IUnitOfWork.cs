using FootballManager.Core.Interfaces.Repository;
using FootballManager.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Tentity> GetRepository<Tentity>() where Tentity : BaseEntity;
        Task CommitAsync();
        void Commit();
    }
}
