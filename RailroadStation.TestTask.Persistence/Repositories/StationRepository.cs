using RailroadStation.TestTask.Domain.Contracts;
using RailroadStation.TestTask.Domain.Stations.Entities;
using RailroadStation.TestTask.Persistence.Data;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Persistence.Repositories
{
    public class StationRepository: Repository<Station>, IStationRepository
    {
        protected override IEnumerable<Station> DataSource => Stations.Data;
    }
}
