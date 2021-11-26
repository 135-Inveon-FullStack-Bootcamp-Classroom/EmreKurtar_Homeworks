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
        IMovieRepository movieRepository { get; }
        IActorRepository actorRepository { get; }
        IDirectorRepository directorRepository { get; }
        ICommentRepository commentRepository { get; }

        Task CommitAsync();
        void Commit();

    }
}
