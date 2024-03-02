using RailroadStation.TestTask.Domain.Stations.Entities;

namespace RailroadStation.TestTask.Domain.Contracts
{
    public interface IStationRepository
    {
        Station? GetByKey(long key);
    }
}
