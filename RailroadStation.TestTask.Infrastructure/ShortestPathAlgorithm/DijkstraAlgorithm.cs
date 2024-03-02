using CSharpFunctionalExtensions;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using RailroadStation.TestTask.Application.Core.Abstractions;
using RailroadStation.TestTask.Domain.Stations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RailroadStation.TestTask.Infrastructure.ShortestPathAlgorithm
{
    /// <summary>
    /// Алгоритм Дейксты поиска кратчайшего пути
    /// основано на реализации https://github.com/matiii/Dijkstra.NET/tree/master
    /// </summary>
    public class DijkstraAlgorithm : IShortestPathAlgorithm
    {
        public Result<ICollection<Segment>> Search(ICollection<Segment> segments, Segment start, Segment end)
        {
            var graph = new Graph<Point, string>();

            // строим дерево
            uint internalKey = 0;
            var points = segments
                .SelectMany(x => new[] { x.Start, x.End })
                .Distinct()
                .ToDictionary(x => x, x => ++internalKey);

            // узлы
            foreach (var point in points)
                graph.AddNode(point.Key);

            // ребра
            segments
                .Select(x => graph.Connect(points[x.Start], points[x.End], ConvertToInt(x.GetLength()), null))
                .ToList();

            var searchResult = graph.Dijkstra(points[start.End], points[end.Start]);

            if (!searchResult.IsFounded)
                return Result.Failure<ICollection<Segment>>("Не удалось построить кратчайший путь.");

            // собираем итоговый путь
            var result = new List<Segment> { start };

            var path = searchResult.GetPath().Select(x => ResolvePoint(points, x)).ToArray();
            for (var i = 0; i < path.Length - 1; i++)
                result.Add(segments.First(s => s.Start == path[i] && s.End == path[i + 1]));
            result.Add(end);

            return Result.Success<ICollection<Segment>>(result);
        }

        private Point ResolvePoint(IDictionary<Point, uint> points, uint key) =>
            points.First(x => x.Value == key).Key;

        /// <summary>
        /// Т.к. алгоритм рассчитан на работу с целыми числами конвертим дробное в целое с точностью 6 знаков после запятой
        /// </summary>
        private int ConvertToInt(decimal source) =>
            (int)Math.Truncate(source * (decimal)Math.Pow(10, 6));
        private decimal ConvertToDecimal(int source) =>
            (decimal)source / (decimal)Math.Pow(10, 6);
    }
}
