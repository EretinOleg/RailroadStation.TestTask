namespace RailroadStation.TestTask.Domain.Stations.Entities
{
    /// <summary>
    /// Отрезок пути
    /// </summary>
    public class Segment : Core.Primitives.Entity
    {
        // todo: предполагаем что есть начало и конец, возможно в реальности отрезок ненаправленный
        public Node Start { get; set; }
        public Node End { get; set; }
        public decimal Distance { get; set; } // todo: возможно вычисляется исходя из параметров точек

        public Segment(long key, Node start, Node end, decimal distance) : base(key)
        {
            Start = start;
            End = end;
            Distance = distance;
        }
    }
}
