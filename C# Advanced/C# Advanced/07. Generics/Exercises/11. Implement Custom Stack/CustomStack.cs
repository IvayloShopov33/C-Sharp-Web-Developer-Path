using System.Collections;

namespace _11._Implement_Custom_Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;

        public CustomStack()
        {
            this.items = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[this.Count++] = item;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            T item = this.items[this.Count - 1];
            this.Count--;

            if (this.Count <= this.items.Length / 4)
            {
                Shrink();
            }

            return item;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            return this.items[this.Count - 1];
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

        private void Shrink()
        {
            T[] tempArray = new T[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.items[i];
            }

            this.items = tempArray;
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
