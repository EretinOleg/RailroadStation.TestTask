using CSharpFunctionalExtensions;

namespace RailroadStation.TestTask.Domain.Core.Primitives
{
    /// <summary>
    /// Базовый класс для всех бизнес-сущностей
    /// </summary>
    public abstract class Entity : Entity<long>
    {
        protected Entity()
        {
        }

        protected Entity(long id) : base(id)
        {
        }
    }
}
