using Microsoft.Extensions.DependencyInjection;
using RailroadStation.TestTask.Persistence.Repositories;

namespace RailroadStation.TestTask.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            // add repositories
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(Repository<>))
                .AddClasses(classes => classes.AssignableTo(typeof(Repository<>)))
                .AsMatchingInterface()
                .WithScopedLifetime());

            return services;
        }
    }
}
