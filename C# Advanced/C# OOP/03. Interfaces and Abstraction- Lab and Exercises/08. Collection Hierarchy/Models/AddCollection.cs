using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddCollection<T> : IAddCollection<T>
    {
        private readonly ICollection<T> collection;

        public AddCollection()
        {
            this.collection = new List<T>();
        }

        public int Add(T item)
        {
            this.collection.Add(item);

            return this.collection.Count - 1;
        }
    }
}
