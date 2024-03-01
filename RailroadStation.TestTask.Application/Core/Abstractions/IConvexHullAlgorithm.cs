using CSharpFunctionalExtensions;
using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Application.Core.Abstractions
{
    /// <summary>
    /// Алгоритм построения выпуклой оболочки для набора точек
    /// возможные реализации - https://en.wikipedia.org/wiki/Convex_hull_algorithms#Algorithms
    /// </summary>
    public interface IConvexHullAlgorithm
    {
        /// <summary>
        /// Построить оболочку
        /// </summary>
        Result<List<Point>> BuildConvexHull(IList<Point> points);
    }
}
