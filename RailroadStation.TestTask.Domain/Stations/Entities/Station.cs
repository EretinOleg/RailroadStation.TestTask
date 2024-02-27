using CSharpFunctionalExtensions;
using RailroadStation.TestTask.Domain.Core.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace RailroadStation.TestTask.Domain.Stations.Entities
{
    public class Station : Core.Primitives.Entity
    {
        private List<Park> _parks = new();
        public IReadOnlyCollection<Park> Parks => _parks.AsReadOnly();

        public Station(long key) : base(key) { }

        /// <summary>
        /// Добавляет отрезок к пути
        /// </summary>
        public UnitResult<Error> AddRoute(Park park)
        {
            if (_parks.Any(x => x == park))
                return UnitResult.Failure(Errors.Station.DuplicatePark);

            _parks.Add(park);
            return UnitResult.Success<Error>();
        }
    }
}
