using RailroadStation.TestTask.Domain.Core.Primitives;

namespace RailroadStation.TestTask.Domain.Stations.Errors
{
    public static class Route
    {
        public static Error InconsistentSegment => new Error("Route.InconsistentSegment", "Добавляемый отрезок должен начинаться в текущем конце пути.");
    }
}
