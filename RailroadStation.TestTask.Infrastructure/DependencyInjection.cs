using Microsoft.Extensions.DependencyInjection;
using RailroadStation.TestTask.Application.Core.Abstractions;
using RailroadStation.TestTask.Infrastructure.ConvexHullAlgorithm;

namespace RailroadStation.TestTask.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IConvexHullAlgorithm, GiftWrappingAlgorithm>();

            return services;
        }
    }
}
