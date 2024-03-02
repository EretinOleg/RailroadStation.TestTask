using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RailroadStation.TestTask.ConsoleApp
{
    internal static class HostExtensions
    {
        public static ISender GetSender(this IHost host) =>
            host.Services.GetRequiredService<ISender>();
    }
}
