using CSharpFunctionalExtensions;
using RailroadStation.TestTask.Application.Core.Abstractions;
using RailroadStation.TestTask.Domain.Stations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RailroadStation.TestTask.Infrastructure.ConvexHullAlgorithm
{
    /// <summary>
    /// Алгоритм Джарвиса
    /// https://ru.wikipedia.org/wiki/%D0%90%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC_%D0%94%D0%B6%D0%B0%D1%80%D0%B2%D0%B8%D1%81%D0%B0
    /// https://en.wikipedia.org/wiki/Gift_wrapping_algorithm
    /// </summary>
    public class GiftWrappingAlgorithm : IConvexHullAlgorithm
    {
        public Result<List<Point>> BuildConvexHull(IList<Point> points)
        {
            if (points.Count < 3)
                return Result.Failure<List<Point>>("Недостаточно точек. Необходимо как минимум 3 точки.");

            List<Point> hull = new List<Point>();

            // get leftmost point
            Point vPointOnHull = points.Where(p => p.X == points.Min(min => min.X)).First();

            Point vEndpoint;
            do
            {
                hull.Add(vPointOnHull);
                vEndpoint = points[0];

                for (int i = 1; i < points.Count; i++)
                {
                    if ((vPointOnHull == vEndpoint)
                        || (Orientation(vPointOnHull, vEndpoint, points[i]) == -1))
                    {
                        vEndpoint = points[i];
                    }
                }

                vPointOnHull = vEndpoint;

            }
            while (vEndpoint != hull[0]);

            return Result.Success(hull);
        }

        private int Orientation(Point p1, Point p2, Point p)
        {
            // Determinant
            var Orin = (p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y);

            if (Orin > 0)
                return -1;
            if (Orin < 0)
                return 1;

            return 0;
        }
    }
}
