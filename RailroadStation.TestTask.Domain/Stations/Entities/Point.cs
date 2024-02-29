namespace RailroadStation.TestTask.Domain.Stations.Entities
{
    /// <summary>
    /// Точка
    /// </summary>
    public class Point : Core.Primitives.Entity
    {
        public decimal X { get; private set; }
        public decimal Y { get; private set; }

        public Point(long key, decimal x, decimal y) : base(key) 
        { 
            X = x;
            Y = y;
        }

        public override string ToString() => $"Точка {Id}";
    }
}
