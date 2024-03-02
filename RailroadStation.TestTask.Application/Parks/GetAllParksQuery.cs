using RailroadStation.TestTask.Application.Contracts.Messaging;
using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Application.Parks
{
    /// <summary>
    /// Запрос на получение списка парков
    /// </summary>
    public record GetAllParksQuery() : IQuery<ICollection<Park>>;
}
