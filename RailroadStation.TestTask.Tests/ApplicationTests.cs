using Moq;
using RailroadStation.TestTask.Application.Parks;
using RailroadStation.TestTask.Domain.Contracts;
using RailroadStation.TestTask.Domain.Stations.Entities;
using RailroadStation.TestTask.Infrastructure.ConvexHullAlgorithm;
using System.Threading;
using Xunit;

namespace RailroadStation.TestTask.Tests
{
    public class ApplicationTests
    {
        [Fact]
        public async void GetAllParksQuery()
        {
            var parkRepositoryMock = new Mock<IParkRepository>();
            parkRepositoryMock.Setup(x => x.GetAll()).Returns(new[] { new Park(1), new Park(2), new Park(3) });

            var result = await new GetAllParksQueryHandler(parkRepositoryMock.Object)
                .Handle(new GetAllParksQuery(), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async void ParkFillQuery()
        {
            var point1 = new Point(1, 5.0m, 2.0m);
            var point2 = new Point(2, 6.0m, 4.0m);
            var segment1 = Segment.Create(1, point1, point2);

            var point3 = new Point(3, 8.0m, 2.0m);
            var segment2 = Segment.Create(2, point2, point3);

            var route1 = new Route(1);
            route1.AddSegment(segment1.Value);
            route1.AddSegment(segment2.Value);

            var point4 = new Point(4, 4.0m, 8.0m);
            var point5 = new Point(5, 8.0m, 7.0m);
            var segment3 = Segment.Create(3, point4, point5);

            var route2 = new Route(2);
            route2.AddSegment(segment3.Value);

            var park = new Park(1);
            park.AddRoute(route1);
            park.AddRoute(route2);

            var parkRepositoryMock = new Mock<IParkRepository>();
            parkRepositoryMock.Setup(x => x.GetByKey(It.IsAny<long>())).Returns(park);

            var result = await new ParkFillingQueryHandler(parkRepositoryMock.Object, new GiftWrappingAlgorithm())
                .Handle(new ParkFillingQuery(1), CancellationToken.None);

            Assert.True(result.IsSuccess);
            Assert.Equal(4, result.Value.Count);
            Assert.DoesNotContain(point2, result.Value);
        }
    }
}
