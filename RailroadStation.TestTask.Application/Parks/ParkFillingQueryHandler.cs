using CSharpFunctionalExtensions;
using RailroadStation.TestTask.Application.Contracts.Messaging;
using RailroadStation.TestTask.Application.Core.Abstractions;
using RailroadStation.TestTask.Domain.Contracts;
using RailroadStation.TestTask.Domain.Core.Primitives;
using RailroadStation.TestTask.Domain.Stations.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RailroadStation.TestTask.Application.Parks
{
    /// <summary>
    /// Обработчик запроса на заливку парка
    /// </summary>
    public class ParkFillingQueryHandler: IQueryHandler<ParkFillingQuery, Result<ICollection<Point>, Error>>
    {
        private readonly IParkRepository _parkRepository;
        private readonly IConvexHullAlgorithm _algorithm;

        public ParkFillingQueryHandler(
            IParkRepository parkRepository, 
            IConvexHullAlgorithm algorithm)
        {
            _parkRepository = parkRepository;
            _algorithm = algorithm;
        }

        public Task<Result<ICollection<Point>, Error>> Handle(ParkFillingQuery request, CancellationToken cancellationToken)
        {
            var park = _parkRepository.GetByKey(request.ParkKey);

            if (park is null)
                return Task.FromResult(Result.Failure<ICollection<Point>, Error>(Domain.Stations.Errors.Park.NotFound));

            var result = _algorithm.BuildConvexHull(park.CollectPoints().ToList());

            return result.IsSuccess
                ? Task.FromResult(Result.Success<ICollection<Point>, Error>(result.Value))
                : Task.FromResult(Result.Failure<ICollection<Point>, Error>(new Error("IConvexHullAlgorithm", result.Error)));
        }
    }
}
