using RailroadStation.TestTask.Domain.Stations.Entities;

namespace RailroadStation.TestTask.Domain.Contracts
{
    public interface IRouteRepository
    {
        Route? GetByKey(long key);
    }
}
