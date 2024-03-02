using CSharpFunctionalExtensions;
using RailroadStation.TestTask.Domain.Core.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace RailroadStation.TestTask.Domain.Stations.Entities
{
    /// <summary>
    /// Станция
    /// </summary>
    public class Station : Core.Primitives.Entity
    {
        private List<Park> _parks = new();
        public IReadOnlyCollection<Park> Parks => _parks.AsReadOnly();

        // пути не входящие в парки
        private List<Route> _routes = new();
        public IReadOnlyCollection<Route> Routes => _routes.AsReadOnly();

        public Station(long key) : base(key) { }

        /// <summary>
        /// Добавляет парк
        /// </summary>
        public UnitResult<Error> AddPark(Park park)
        {
            if (_parks.Any(x => x == park))
                return UnitResult.Failure(Errors.Station.DuplicatePark);

            _parks.Add(park);
            return UnitResult.Success<Error>();
        }

        /// <summary>
        /// Добавляет путь
        /// </summary>
        public UnitResult<Error> AddRoute(Route route)
        {
            if (_routes.Any(x => x == route))
                return UnitResult.Failure(Errors.Station.DuplicateRoute);

            _routes.Add(route);
            return UnitResult.Success<Error>();
        }

        /// <summary>
        /// Добавляет путь к парку
        /// </summary>
        public UnitResult<Error> AddRoute(Route route, Park park)
        {
            var exisitngPark = _parks.FirstOrDefault(x => x == park);
            if (exisitngPark is null)
                return UnitResult.Failure(Errors.Station.ParkNotFound);

            exisitngPark.AddRoute(route);

            // если путь не принадлежал никакому парку убираем его
            var existingRoute = _routes.FirstOrDefault(x => x == route);
            if (existingRoute is not null)
                _routes.Remove(route);
            
            return UnitResult.Success<Error>();
        }

        /// <summary>
        /// Получить все пути станции
        /// </summary>
        public ICollection<Route> CollectRoutes() =>
            _parks.SelectMany(p => p.Routes)
            .Union(_routes)
            .Distinct()
            .ToList();
    }
}
