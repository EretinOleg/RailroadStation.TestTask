using RailroadStation.TestTask.Domain.Contracts;
using RailroadStation.TestTask.Domain.Stations.Entities;
using RailroadStation.TestTask.Persistence.Data;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Persistence.Repositories
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        protected override IEnumerable<Route> DataSource => Routes.Data;
    }
}
