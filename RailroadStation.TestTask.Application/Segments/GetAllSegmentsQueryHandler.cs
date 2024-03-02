using RailroadStation.TestTask.Application.Contracts.Messaging;
using RailroadStation.TestTask.Domain.Contracts;
using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RailroadStation.TestTask.Application.Segments
{
    internal class GetAllSegmentsQueryHandler: IQueryHandler<GetAllSegmentsQuery, ICollection<Segment>>
    {
        private readonly ISegmentRepository _segmentRepository;

        public GetAllSegmentsQueryHandler(
            ISegmentRepository segmentRepository)
        {
            _segmentRepository = segmentRepository;
        }

        public Task<ICollection<Segment>> Handle(GetAllSegmentsQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(_segmentRepository.GetAll());
    }
}
