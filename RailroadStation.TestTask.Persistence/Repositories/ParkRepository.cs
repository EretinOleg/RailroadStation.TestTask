using RailroadStation.TestTask.Domain.Contracts;
using RailroadStation.TestTask.Domain.Stations.Entities;
using RailroadStation.TestTask.Persistence.Data;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Persistence.Repositories
{
    public class ParkRepository : Repository<Park>, IParkRepository
    {
        protected override IEnumerable<Park> DataSource => Parks.Data;
    }
}
