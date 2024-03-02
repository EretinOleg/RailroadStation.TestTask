using RailroadStation.TestTask.Domain.Core.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace RailroadStation.TestTask.Persistence.Repositories
{
    /// <summary>
    /// Базовый репозиторий
    /// </summary>
    public abstract class Repository<T> where T : Entity
    {
        protected abstract IEnumerable<T> DataSource { get; }

        public ICollection<T> GetAll() => DataSource.ToList();

        public T? GetByKey(long key) => DataSource.FirstOrDefault(x => x.Id == key);
    }
}
