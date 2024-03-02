using CSharpFunctionalExtensions;
using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Application.Core.Abstractions
{
    /// <summary>
    /// Алгоритм поиска кратчайшего пути
    /// </summary>
    public interface IShortestPathAlgorithm
    {
        /// <summary>
        /// Найти кратчайший путь
        /// </summary>
        Result<ICollection<Segment>> Search(ICollection<Segment> segments, Segment start, Segment end);
    }
}
