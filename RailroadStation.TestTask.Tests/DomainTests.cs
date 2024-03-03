using RailroadStation.TestTask.Domain.Stations.Entities;
using Xunit;

namespace RailroadStation.TestTask.Tests
{
    /// <summary>
    /// Тесты структуры и целостности доменной моедли
    /// </summary>
    public class DomainTests
    {
        [Fact]
        public void SinglePointSegment()
        {
            var point = new Point(1, 0.0m, 0.0m);

            var result = Segment.Create(1, point, point);

            Assert.False(result.IsSuccess);
            Assert.Equal(Domain.Stations.Errors.Segment.SamePoints, result.Error);
        }

        [Fact]
        public void SamePointsSegment()
        {
            var point1 = new Point(1, 0.0m, 0.0m);
            var point2 = new Point(2, 0.0m, 0.0m);

            var result = Segment.Create(1, point1, point2);

            Assert.False(result.IsSuccess);
            Assert.Equal(Domain.Stations.Errors.Segment.SamePoints, result.Error);
        }

        [Fact]
        public void SegmentLength()
        {
            var point1 = new Point(1, 0.0m, 0.0m);
            var point2 = new Point(2, 3.0m, 4.0m);

            var result = Segment.Create(1, point1, point2);

            Assert.True(result.IsSuccess);
            Assert.Equal(5.0m, result.Value.GetLength());
        }

        [Fact]
        public void SimpleRoute()
        {
            var point1 = new Point(1, 0.0m, 0.0m);
            var point2 = new Point(2, 3.0m, 4.0m);
            var segment = Segment.Create(1, point1, point2);
            var route = new Route(1);

            var result = route.AddSegment(segment.Value);

            Assert.True(result.IsSuccess);
            Assert.Equal(route.GetStart(), point1);
            Assert.Equal(route.GetEnd(), point2);
            Assert.Equal(route.GetLength(), segment.Value.GetLength());
        }

        [Fact]
        public void CompositeRoute()
        {
            var point1 = new Point(1, 0.0m, 0.0m);
            var point2 = new Point(2, 3.0m, 4.0m);
            var segment1 = Segment.Create(1, point1, point2);

            var point3 = new Point(3, 7.0m, 7.0m);
            var segment2 = Segment.Create(2, point2, point3);

            var route = new Route(1);

            route.AddSegment(segment1.Value);
            var result = route.AddSegment(segment2.Value);

            Assert.True(result.IsSuccess);
            Assert.Equal(route.GetStart(), point1);
            Assert.Equal(route.GetEnd(), point3);
        }

        [Fact]
        public void DuplicateRouteInPark()
        {
            var route = new Route(1);

            var park = new Park(1);
            park.AddRoute(route);
            var result = park.AddRoute(route);
           
            Assert.False(result.IsSuccess);
            Assert.Equal(result.Error, Domain.Stations.Errors.Park.DuplicateRoute);
        }

        [Fact]
        public void DuplicateParkInStation()
        {
            var park = new Park(1);

            var station = new Station(1);
            station.AddPark(park);
            var result = station.AddPark(park);

            Assert.False(result.IsSuccess);
            Assert.Equal(result.Error, Domain.Stations.Errors.Station.DuplicatePark);
        }
    }
}
