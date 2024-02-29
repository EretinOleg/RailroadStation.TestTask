using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Concurrent;
using System.Linq;

namespace RailroadStation.TestTask.Persistence.Data
{
    internal static class Segments
    {
        internal static ConcurrentBag<Segment> Data = new();

        static Segments()
        {
            Data.Add(Segment.Create(1, GetProint(1), GetProint(2)).Value);
            Data.Add(Segment.Create(2, GetProint(2), GetProint(3)).Value);
            Data.Add(Segment.Create(3, GetProint(3), GetProint(4)).Value);
            Data.Add(Segment.Create(4, GetProint(4), GetProint(5)).Value);
            Data.Add(Segment.Create(5, GetProint(5), GetProint(6)).Value);
            Data.Add(Segment.Create(6, GetProint(2), GetProint(7)).Value);
            Data.Add(Segment.Create(7, GetProint(7), GetProint(8)).Value);
            Data.Add(Segment.Create(8, GetProint(8), GetProint(5)).Value);
            Data.Add(Segment.Create(9, GetProint(3), GetProint(9)).Value);
            Data.Add(Segment.Create(10, GetProint(9), GetProint(10)).Value);
            Data.Add(Segment.Create(11, GetProint(10), GetProint(11)).Value);
            Data.Add(Segment.Create(12, GetProint(11), GetProint(6)).Value);
            Data.Add(Segment.Create(13, GetProint(1), GetProint(12)).Value);
            Data.Add(Segment.Create(14, GetProint(12), GetProint(13)).Value);
            Data.Add(Segment.Create(15, GetProint(13), GetProint(10)).Value);
            Data.Add(Segment.Create(16, GetProint(13), GetProint(14)).Value);
        }

        private static Point GetProint(long key) =>
            Points.Data.First(x => x.Id == key);
    }
}
