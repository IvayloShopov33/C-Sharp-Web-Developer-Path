using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private readonly IList<T> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<T>();
        }

        public int Add(T item)
        {
            this.collection.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            if (this.collection.Count == 0)
            {
                return default(T);
            }

            T itemToRemove = this.collection[this.collection.Count - 1];
            this.collection.RemoveAt(this.collection.Count - 1);

            return itemToRemove;
        }
    }
}
