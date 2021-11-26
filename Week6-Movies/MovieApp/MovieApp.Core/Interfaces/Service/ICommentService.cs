using MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Interfaces.Service
{
    public interface ICommentService : IService<Comment>
    {
        // I've created this service from generic service interface
        //      because here we can handle some business operation 
    }
}
