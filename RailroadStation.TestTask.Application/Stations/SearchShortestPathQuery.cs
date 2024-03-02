using CSharpFunctionalExtensions;
using RailroadStation.TestTask.Application.Contracts.Messaging;
using RailroadStation.TestTask.Domain.Core.Primitives;
using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Application.Stations
{
    /// <summary>
    /// Запрос на поиск кратчайшего маршрута между участками пути
    /// </summary>
    public record SearchShortestPathQuery(int Start, int End) : IQuery<Result<ICollection<Segment>, Error>>;
}
