namespace MiniORM
{
    public class ChangeTracker<T>
        where T : class, new()
    {
        private readonly List<T> allEntities;
        private readonly List<T> added;
        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            this.added = new List<T>();
            this.removed = new List<T>();
            this.allEntities = CloneEntities(entities).ToList();
        }

        public IReadOnlyCollection<T> AllEntities => this.allEntities.AsReadOnly();
        public IReadOnlyCollection<T> Added => this.added.AsReadOnly();
        public IReadOnlyCollection<T> Removed => this.removed.AsReadOnly();

        private static IEnumerable<T> CloneEntities(IEnumerable<T> entities)
        {
            var propertiesToClone = typeof(T).GetAllowedSqlProperties();

            List<T> result = new List<T>();
            foreach (var entity in entities) 
            {
                var copy = new T();

                foreach (var property in propertiesToClone) 
                {
                    var value = property.GetValue(entity);
                    property.SetValue(copy, value);
                }

                result.Add(copy);
            }

            return result;
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            this.added.Add(item);
        }

        public void Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            this.removed.Remove(item);
        }

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            var result = new List<T>();

            var entityType = typeof(T);
            var primaryKeyProperties = entityType.GetKeyProperties();

            foreach (var clonedEntity in this.AllEntities)
            {
                var primaryKey = primaryKeyProperties.Select(p => p.GetValue(clonedEntity));
                var correspondingEntity = dbSet.SingleOrDefault(e => primaryKeyProperties.Select(p => p.GetValue(e)).SequenceEqual(primaryKey));

                if (correspondingEntity is not null && IsModified(clonedEntity, correspondingEntity)) result.Add(correspondingEntity);
            }

            return result;
        }

        private static bool IsModified(T originalEntity, T currentEntity)
        {
            foreach (var property in typeof(T).GetAllowedSqlProperties())
            {
                if (!Equals(property.GetValue(originalEntity), property.GetValue(currentEntity)))
                    return true;
            }

            return false;
        }
    }
}