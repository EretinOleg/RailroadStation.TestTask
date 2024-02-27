using RailroadStation.TestTask.Domain.Core.Primitives;

namespace RailroadStation.TestTask.Domain.Stations.Errors
{
    public static class Station
    {
        public static Error DuplicatePark => new Error("Station.DuplicatePark", "Данный парк уже присутствует на станции.");
    }
}
