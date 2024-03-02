using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Domain.Contracts
{
    public interface ISegmentRepository
    {
        ICollection<Segment> GetAll();

        Segment? GetByKey(long key);
    }
}
