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
        public static void AddMyContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FootballDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("MyConn")));
            
        }

        public static void AddMyServices(this IServiceCollection services)
        {
            Type type = typeof(IService);
            Assembly assembly = type.Assembly;
            Type[] typesInAssembly = assembly.GetTypes();
            var interfaces = typesInAssembly.Where(x => x.IsAssignableFrom(x) && x.IsInterface && x != type);
            foreach (var iFace in interfaces)
            {
                var implementClass = typesInAssembly.Where(q => q.IsClass && q.IsAssignableFrom(q)).FirstOrDefault();
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
