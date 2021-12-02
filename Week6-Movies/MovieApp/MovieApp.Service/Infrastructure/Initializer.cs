using Microsoft.Extensions.DependencyInjection;
using MovieApp.Service.Interfaces;
using System.Linq;

namespace MovieApp.Service.Infrastructure
{
    public static class Initializer
    {
        public static void AddServices(this IServiceCollection services)
        {
            var baseType = typeof(IService);
            var assembly = baseType.Assembly;
            var allTypes = assembly.GetTypes();
            var iFaces = allTypes.Where(q => baseType.IsAssignableFrom(q) && q.IsInterface && q != baseType);
            foreach (var iFace in iFaces)
            {
                var implementedClass = allTypes.Where(q => q.IsClass && iFace.IsAssignableFrom(q)).FirstOrDefault();
                services.AddTransient(iFace, implementedClass);
            }
        }
    }
}
