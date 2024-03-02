using RailroadStation.TestTask.Domain.Core.Primitives;

namespace RailroadStation.TestTask.Domain.Stations.Errors
{
    public static class Station
    {
        public static Error DuplicatePark => new Error("Station.DuplicatePark", "Данный парк уже присутствует на станции.");

        public static Error DuplicateRoute => new Error("Station.DuplicateRoute", "Данный путь уже присутствует на станции.");

        public static Error ParkNotFound => new Error("Station.ParkNotFound", "Парк не найден.");

        public static Error NotFound => new Error("Station.NotFound", "Станция не найдена.");
    }
}
