namespace _10._Custom_Data_Structures
{
    public class CustomList
    {
        private const int DefaultCapacity = 2;
        private int[] items;

        public CustomList()
        {
            items = new int[DefaultCapacity];
        }

        public int Count { get; private set; }

        public int this[int i]
        {
            get
            {
                IsInRange(i);
                return this.items[i];
            }
            set
            {
                IsInRange(i);
                this.items[i] = value;
            }
        }


        public void Add(int element)
        {
            if (this.Count == items.Length)
            {
                Resize();
            }

            items[this.Count++] = element;
        }

        public int RemoveAt(int index)
        {
            IsInRange(index);
            int item = this.items[index];
            this.items[index] = 0;
            Shift(index);

            this.Count--;
            if (this.Count <= this.items.Length / 4)
            {
                Shrink();
            }

            return item;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= this.Count || secondIndex < 0 || secondIndex >= this.Count)
            {
                throw new IndexOutOfRangeException("index is out of bounds of the list!");
            }

            int tempElement = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = tempElement;
        }

        public void Print()
        {
            if (this.Count >= 1)
            {
                this.items = this.items.Where(x => x != 0).ToArray();
            }

            Console.WriteLine(string.Join(", ", this.items));
        }

        private void IsInRange(int i)
        {
            if (i < 0 || i >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is out of bounds of the list!");
            }
        }

        private void Resize()
        {
            int[] tempArray = new int[items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                tempArray[i] = this.items[i];
            }

            this.items = tempArray;
        }

        private void Shrink()
        {
            int[] tempArray = new int[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.items[i];
            }

            this.items = tempArray;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                int temp = this.items[i];
                this.items[i] = this.items[i + 1];
                this.items[i + 1] = temp;
            }
        }
    }
}
