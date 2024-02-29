﻿using RailroadStation.TestTask.Domain.Core.Primitives;

namespace RailroadStation.TestTask.Domain.Stations.Errors
{
    public static class Segment
    {
        public static Error SamePoints => new Error("Segment.SamePoints", "Участок не может состоять из одной точки.");
    }
}
