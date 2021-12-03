using FootballManager.Service.Interfaces;
using FootballManager.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FootballManager.Core.Interfaces.UnitOfWork;
using FootballManager.Data.UnitOfWork;

namespace FootballManager.Service.Infrastructure
{
    public static class Initializer
    {
        public static IServiceCollection AddMyContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FootballDbContext>(
                options =>
               options.UseSqlServer(configuration.GetConnectionString("MyConn"),o => { o.MigrationsAssembly("FootballManager.Data"); }));
            return services;
            
        }

        public static void AddMyServices(this IServiceCollection services)
        {
            Type type = typeof(IService);
            Assembly assembly = type.Assembly;
            Type[] typesInAssembly = assembly.GetTypes();
            var interfaces = typesInAssembly.Where(x => type.IsAssignableFrom(x) && x.IsInterface && x != type);
            foreach (var iFace in interfaces)
            {
                var implementClass = typesInAssembly.Where(q => q.IsClass && iFace.IsAssignableFrom(q)).FirstOrDefault();
                if(implementClass != null)
                {
                    services.AddTransient(iFace, implementClass);
                }
            }
        }

        public static void AddUnitOfWorkService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
