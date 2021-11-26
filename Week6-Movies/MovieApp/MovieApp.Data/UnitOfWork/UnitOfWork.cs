using MovieApp.Core.Interfaces.Repository;
using MovieApp.Core.Interfaces.UnitOfWork;
using MovieApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieDBContext _context;

        private MovieRepository _movieRepository;
        private ActorRepository _actorRepository;
        private DirectorRepository _directorRepository;
        private CommentRepository _commentRepository;

        public UnitOfWork(MovieDBContext context)
        {
            _context = context;
        }

        public IMovieRepository movieRepository => _movieRepository = _movieRepository ?? new MovieRepository(_context);

        public IActorRepository actorRepository => _actorRepository = _actorRepository ?? new ActorRepository(_context);

        public IDirectorRepository directorRepository => _directorRepository = _directorRepository ?? new DirectorRepository(_context);

        public ICommentRepository commentRepository => _commentRepository = _commentRepository ?? new CommentRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
