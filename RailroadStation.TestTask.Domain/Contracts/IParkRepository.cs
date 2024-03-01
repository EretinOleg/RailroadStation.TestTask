using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Domain.Contracts
{
    public interface IParkRepository
    {
        ICollection<Park> GetAll();

        Park? GetByKey(long key);
    }
}
