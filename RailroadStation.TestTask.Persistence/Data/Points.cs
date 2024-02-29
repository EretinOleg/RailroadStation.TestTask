using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Concurrent;

namespace RailroadStation.TestTask.Persistence.Data
{
    internal static class Points
    {
        internal static ConcurrentBag<Point> Data = new();

        static Points()
        {
            Data.Add(new Point(1, 2.0m, 4.0m));
            Data.Add(new Point(2, 4.0m, 4.0m));
            Data.Add(new Point(3, 6.0m, 4.0m));
            Data.Add(new Point(4, 8.0m, 4.0m));
            Data.Add(new Point(5, 13.0m, 4.0m));
            Data.Add(new Point(6, 15.0m, 4.0m));
            Data.Add(new Point(7, 5.0m, 2.0m));
            Data.Add(new Point(8, 8.0m, 2.0m));
            Data.Add(new Point(9, 7.0m, 6.0m));
            Data.Add(new Point(10, 10.0m, 6.0m));
            Data.Add(new Point(11, 13.0m, 6.0m));
            Data.Add(new Point(12, 4.0m, 9.0m));
            Data.Add(new Point(13, 8.0m, 9.0m));
            Data.Add(new Point(14, 12.0m, 9.0m));
        }
    }
}
