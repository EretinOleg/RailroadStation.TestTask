using RailroadStation.TestTask.Domain.Core.Primitives;
using System.Collections.Generic;

namespace RailroadStation.TestTask.Persistence.Repositories
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    public abstract class Repository<T> where T : Entity
    {
        protected abstract IEnumerable<T> DataSource { get; }
    }
}
