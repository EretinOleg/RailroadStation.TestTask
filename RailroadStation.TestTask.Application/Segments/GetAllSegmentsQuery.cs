using RailroadStation.TestTask.Application.Contracts.Messaging;
using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Application.Segments
{
    public record GetAllSegmentsQuery() : IQuery<ICollection<Segment>>;
}
