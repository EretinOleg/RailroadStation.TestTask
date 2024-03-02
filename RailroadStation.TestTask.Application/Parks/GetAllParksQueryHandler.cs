using RailroadStation.TestTask.Application.Contracts.Messaging;
using RailroadStation.TestTask.Domain.Contracts;
using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RailroadStation.TestTask.Application.Parks
{
    internal class GetAllParksQueryHandler : IQueryHandler<GetAllParksQuery, ICollection<Park>>
    {
        private readonly IParkRepository _parkRepository;

        public GetAllParksQueryHandler(
            IParkRepository parkRepository)
        {
            _parkRepository = parkRepository;
        }

        public Task<ICollection<Park>> Handle(GetAllParksQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(_parkRepository.GetAll());
    }
}
