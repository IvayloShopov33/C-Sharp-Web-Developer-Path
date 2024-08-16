using System.Collections;

namespace _12._Implement_Custom_Queue
{
    internal class CustomQueue<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;

        public CustomQueue()
        {
            this.items = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[this.Count++] = element;
        }

        public T Dequeue()
        {
            IsQueueEmpty();

            T element = this.items[0];
            if (this.Count <= this.items.Length / 4)
            {
                Shrink();
            }

            this.Count--;
            Shift();

            return element;
        }

        public T Peek()
        {
            IsQueueEmpty();

            T element = this.items[0];

            return element;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in this.items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void IsQueueEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
        }

        private void Shrink()
        {
            T[] tempArray = new T[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.items[i];
            }

            this.items = tempArray;
        }

        private void Shift()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void Resize()
        {
            T[] tempArray = new T[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                tempArray[i] = this.items[i];
            }

            this.items = tempArray;
        }
    }
}
