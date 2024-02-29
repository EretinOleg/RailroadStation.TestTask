using CSharpFunctionalExtensions;
using RailroadStation.TestTask.Domain.Core.Primitives;
using System;

namespace RailroadStation.TestTask.Domain.Stations.Entities
{
    /// <summary>
    /// Отрезок пути
    /// </summary>
    public class Segment : Core.Primitives.Entity
    {
        // todo: предполагаем что есть начало и конец, возможно в реальности отрезок ненаправленный
        public Point Start { get; set; }
        public Point End { get; set; }

        private Segment(long key, Point start, Point end) : base(key)
        {
            Start = start;
            End = end;
        }

        public static Result<Segment, Error> Create(long key, Point start, Point end)
        {
            if (start == end)
                return Result.Failure<Segment, Error>(Errors.Segment.SamePoints);

            return Result.Success<Segment, Error>(new Segment(key, start, end));
        }

        /// <summary>
        /// Длина отрезка
        /// </summary>
        public decimal GetLength() =>
            (decimal)Math.Sqrt(Math.Pow((double)(End.X - Start.X), 2) + Math.Pow((double)(End.Y - Start.Y), 2));

        public override string ToString() => $"Отрезок пути {Id}";
    }
}
