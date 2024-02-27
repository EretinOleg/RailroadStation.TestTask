using RailroadStation.TestTask.Domain.Core.Primitives;

namespace RailroadStation.TestTask.Domain.Stations.Errors
{
    public static class Park
    {
        public static Error DuplicateRoute => new Error("Park.DuplicateRoute", "Данный путь уже присутствует в парке.");
    }
}
