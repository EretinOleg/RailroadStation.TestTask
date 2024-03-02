using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Concurrent;
using System.Linq;

namespace RailroadStation.TestTask.Persistence.Data
{
    internal static class Parks
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

            var park2 = new Park(2);
            park2.AddRoute(GetRoute(1));
            park2.AddRoute(GetRoute(3));
            Data.Add(park2);

            var park3 = new Park(3);
            park3.AddRoute(GetRoute(1));
            park3.AddRoute(GetRoute(5));
            Data.Add(park3);
        }

        private static Route GetRoute(long key) =>
            Routes.Data.First(x => x.Id == key);
    }
}
