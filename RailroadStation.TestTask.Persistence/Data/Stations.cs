using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Concurrent;
using System.Linq;

namespace RailroadStation.TestTask.Persistence.Data
{
    internal static class Stations
    {
        internal static ConcurrentBag<Station> Data = new();

        static Stations()
        {
            var station = new Station(1);
            station.AddPark(GetPark(1));
            station.AddPark(GetPark(2));
            station.AddPark(GetPark(3));

            Data.Add(station);
        }

        private static Park GetPark(long key) =>
            Parks.Data.First(x => x.Id == key);

        private static Route GetRoute(long key) =>
            Routes.Data.First(x => x.Id == key);
    }
}
