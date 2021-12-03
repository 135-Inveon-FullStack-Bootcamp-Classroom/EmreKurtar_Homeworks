using FootballManager.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Service.Infrastructure
{
    public static class Initializer
    {
        public static void AddMyContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FootballDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("MyConn")));
            
        }
    }
}
