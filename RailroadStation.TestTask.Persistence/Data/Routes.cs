using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Concurrent;
using System.Linq;

namespace RailroadStation.TestTask.Persistence.Data
{
    internal static class Routes
    {
        internal static ConcurrentBag<Route> Data = new();

        static Routes()
        {
            var route1 = new Route(1);
            route1.AddSegment(GetSegment(1));
            route1.AddSegment(GetSegment(2));
            route1.AddSegment(GetSegment(3));
            route1.AddSegment(GetSegment(4));
            route1.AddSegment(GetSegment(5));
            Data.Add(route1);

            var route2 = new Route(2);
            route2.AddSegment(GetSegment(1));
            route2.AddSegment(GetSegment(6));
            route2.AddSegment(GetSegment(7));
            route2.AddSegment(GetSegment(8));
            route2.AddSegment(GetSegment(5));
            Data.Add(route2);

            var route3 = new Route(3);
            route3.AddSegment(GetSegment(1));
            route3.AddSegment(GetSegment(2));
            route3.AddSegment(GetSegment(9));
            route3.AddSegment(GetSegment(10));
            route3.AddSegment(GetSegment(11));
            route3.AddSegment(GetSegment(12));
            Data.Add(route3);

            var route4 = new Route(4);
            route4.AddSegment(GetSegment(13));
            route4.AddSegment(GetSegment(14));
            route4.AddSegment(GetSegment(15));
            route4.AddSegment(GetSegment(11));
            route4.AddSegment(GetSegment(12));
            Data.Add(route4);

            var route5 = new Route(5);
            route5.AddSegment(GetSegment(13));
            route5.AddSegment(GetSegment(14));
            route5.AddSegment(GetSegment(16));
            Data.Add(route5);
        }

        private static Segment GetSegment(long key) =>
            Segments.Data.First(x => x.Id == key);
    }
}
