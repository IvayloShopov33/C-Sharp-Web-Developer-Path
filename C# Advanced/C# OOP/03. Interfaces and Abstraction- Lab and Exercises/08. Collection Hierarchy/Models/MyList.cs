using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class MyList<T> : IMyList<T>
    {
        private readonly IList<T> collection;

        public MyList()
        {
            this.collection = new List<T>();
        }

        public int Used => this.collection.Count;

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

            T itemToRemove = this.collection[0];
            this.collection.RemoveAt(0);

            return itemToRemove;
        }
    }
}
