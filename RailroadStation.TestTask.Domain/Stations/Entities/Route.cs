using CSharpFunctionalExtensions;
using RailroadStation.TestTask.Domain.Core.Primitives;
using RailroadStation.TestTask.Domain.Stations.Errors;
using System.Collections.Generic;
using System.Linq;

namespace RailroadStation.TestTask.Domain.Stations.Entities
{
    /// <summary>
    /// Путь
    /// </summary>
    public class Route: Core.Primitives.Entity
    {
        private Dictionary<int, Segment> _segments = new(); // todo: словарь, чтобы понимать порядок, возможно списка было бы достаточно

        public IReadOnlyDictionary<int, Segment> Segments => _segments;


        public Route(long key): base(key) { }

        /// <summary>
        /// Добавляет отрезок к пути
        /// </summary>
        public UnitResult<Error> AddSegment(Segment segment)
        {
            // первый просто добавляем
            if (!_segments.Any())
            {
                _segments.Add(1, segment);
                return UnitResult.Success<Error>();
            }

            var last = _segments.Keys.Max();

            // начало нового отрезка должно совпадать с концом пути
            if (_segments[last].End != segment.Start)
                return UnitResult.Failure(Errors.Route.InconsistentSegment);

            _segments.Add(last + 1, segment);
            return UnitResult.Success<Error>();
        }

        /// <summary>
        /// Начало пути
        /// </summary>
        /// <returns></returns>
        public Point? GetStart() => _segments.Any() ? _segments[1].Start : null;

        /// <summary>
        /// Конец пути
        /// </summary>
        public Point? GetEnd()
        {
            if (!_segments.Any())
                return null;

            var last = _segments.Keys.Max();
            return _segments[last].End;
        }

        /// <summary>
        /// Общая длина пути
        /// </summary>
        public decimal GetLength() => _segments.Any() ? _segments.Sum(x => x.Value.GetLength()) : 0.0m;

        /// <summary>
        /// Получить все точки пути
        /// </summary>
        public ICollection<Point> CollectPoints() =>
            _segments.Aggregate(new List<Point>(),
                (points, segment) =>
                {
                    points.Add(segment.Value.Start);
                    points.Add(segment.Value.End);

                    return points;
                })
            .Distinct()
            .ToList();

        public override string ToString() => $"Путь {Id}";
    }
}
