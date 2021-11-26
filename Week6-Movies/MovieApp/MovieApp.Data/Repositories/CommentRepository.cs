using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data.Repositories
{
    public class CommentRepository : Repository<Comment>,ICommentRepository
    {
        public CommentRepository(MovieDBContext context) : base(context)
        {

        }
    }
}
