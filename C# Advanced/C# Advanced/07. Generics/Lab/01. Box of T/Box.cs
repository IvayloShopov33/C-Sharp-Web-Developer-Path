namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> items;

        public Box()
        {
            this.items = new List<T>();
        }

        public int Count => this.items.Count;

        public void Add(T item)
        {
            this.items.Add(item);
        }

        public T Remove()
        {
            T item = this.items[this.Count - 1];
            this.items.RemoveAt(this.Count - 1);

            return item;
        }

        public T[] ToArray()
        {
            return this.items.ToArray();
        }
    }
}
