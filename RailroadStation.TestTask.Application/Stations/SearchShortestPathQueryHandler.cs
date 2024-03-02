using CSharpFunctionalExtensions;
using RailroadStation.TestTask.Application.Contracts.Messaging;
using RailroadStation.TestTask.Application.Core.Abstractions;
using RailroadStation.TestTask.Domain.Contracts;
using RailroadStation.TestTask.Domain.Core.Primitives;
using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RailroadStation.TestTask.Application.Stations
{
    /// <summary>
    /// Обработчик запроса на поиск кратчайшего маршрута между участками пути
    /// </summary>
    internal class SearchShortestPathQueryHandler : IQueryHandler<SearchShortestPathQuery, Result<ICollection<Segment>, Error>>
    {
        private readonly IStationRepository _stationRepository;
        private readonly ISegmentRepository _segmentRepository;
        private readonly IShortestPathAlgorithm _shortestPathAlgorithm;

        public SearchShortestPathQueryHandler(
            IStationRepository stationRepository,
            ISegmentRepository segmentRepository,
            IShortestPathAlgorithm shortestPathAlgorithm)
        {
            _stationRepository = stationRepository;
            _segmentRepository = segmentRepository;
            _shortestPathAlgorithm = shortestPathAlgorithm;
        }

        public Task<Result<ICollection<Segment>, Error>> Handle(SearchShortestPathQuery request, CancellationToken cancellationToken)
        {
            var station = _stationRepository.GetByKey(1);
            if (station is null)
                return Task.FromResult(Result.Failure<ICollection<Segment>, Error>(Domain.Stations.Errors.Station.NotFound));

            var start = _segmentRepository.GetByKey(request.Start);
            var end = _segmentRepository.GetByKey(request.End);
            if (start is null || end is null)
                return Task.FromResult(Result.Failure<ICollection<Segment>, Error>(Domain.Stations.Errors.Segment.NotFound));

            if (start == end)
                return Task.FromResult(Result.Success<ICollection<Segment>, Error>(new List<Segment> { start }));

            var result = _shortestPathAlgorithm.Search(_segmentRepository.GetAll(), start, end);

            return Task.FromResult(result.IsSuccess
                ? Result.Success<ICollection<Segment>, Error>(result.Value)
                : Result.Failure<ICollection<Segment>, Error>(new Error("IShortestPathAlgorithm", result.Error)));
        }
    }
}
