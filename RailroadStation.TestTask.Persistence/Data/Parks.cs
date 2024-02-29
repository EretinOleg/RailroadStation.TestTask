using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Concurrent;
using System.Linq;

namespace RailroadStation.TestTask.Persistence.Data
{
    public static class Parks
    {
        internal static ConcurrentBag<Park> Data = new();

        static Parks()
        {
            var park1 = new Park(1);
            park1.AddRoute(GetRoute(1));
            park1.AddRoute(GetRoute(2));
            park1.AddRoute(GetRoute(3));
            park1.AddRoute(GetRoute(4));
            park1.AddRoute(GetRoute(5));
            Data.Add(park1);
        }

        private static Route GetRoute(long key) =>
            Routes.Data.First(x => x.Id == key);
    }
}
