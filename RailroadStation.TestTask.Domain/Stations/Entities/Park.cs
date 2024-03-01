using CSharpFunctionalExtensions;
using RailroadStation.TestTask.Domain.Core.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace RailroadStation.TestTask.Domain.Stations.Entities
{
    /// <summary>
    /// Парк
    /// </summary>
    public class Park : Core.Primitives.Entity
    {
        private List<Route> _routes = new();
        public IReadOnlyCollection<Route> Routes => _routes.AsReadOnly();

        public Park(long key) : base(key) { }

        /// <summary>
        /// Добавляет путь
        /// </summary>
        public UnitResult<Error> AddRoute(Route route)
        {
            if (_routes.Any(x => x == route))
                return UnitResult.Failure(Errors.Park.DuplicateRoute);

            _routes.Add(route);
            return UnitResult.Success<Error>();
        }

        /// <summary>
        /// Получить все точки парка
        /// </summary>
        public ICollection<Point> CollectPoints() =>
            _routes.Aggregate(new List<Point>(),
                (points, route) =>
                {
                    points.AddRange(route.CollectPoints());

                    return points;
                })
            .Distinct()
            .ToList();


        public override string ToString() => $"Парк {Id}";
    }
}
