using CSharpFunctionalExtensions;
using RailroadStation.TestTask.Application.Contracts.Messaging;
using RailroadStation.TestTask.Domain.Core.Primitives;
using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Application.Parks
{
    /// <summary>
    /// Запрос на заливку парка
    /// </summary>
    public record ParkFillingQuery(long ParkKey) : IQuery<Result<ICollection<Point>, Error>>;
}
