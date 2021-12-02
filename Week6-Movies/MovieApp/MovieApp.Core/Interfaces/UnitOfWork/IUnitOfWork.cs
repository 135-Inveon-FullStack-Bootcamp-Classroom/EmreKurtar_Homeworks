using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        // Değişiklik
        IActorRepository actorRepository { get; }
        // Değişiklik

        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task CommitAsync();
        void Commit();

    }
}
