namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList<T>
    {
        private ListNode<T> firstItem;
        private ListNode<T> lastItem;

        public int Count
        {
            get
            {
                int count = 0;
                ListNode<T> currentElement = this.firstItem;

                while (currentElement != null)
                {
                    currentElement = currentElement.Next;
                    count++;
                }

                return count;
            }
        }

        public void AddFirst(T element)
        {
            ListNode<T> newItem = new ListNode<T>(element);

            // check if there are any elements in the list
            if (this.firstItem == null)
            {
                this.firstItem = newItem;
                this.lastItem = newItem;
            }
            else
            {
                newItem.Next = this.firstItem;
                this.firstItem.Previous = newItem;
                this.firstItem = newItem;
            }
        }

        public void AddLast(T element)
        {
            ListNode<T> newItem = new ListNode<T>(element);

            // check if there are any elements in the list
            if (this.lastItem == null)
            {
                this.firstItem = newItem;
                this.lastItem = newItem;
            }
            else
            {
                newItem.Previous = this.lastItem;
                this.lastItem.Next = newItem;
                this.lastItem = newItem;
            }
        }

        public T RemoveFirst()
        {
            // check if there are no elements in the list
            if (this.firstItem != null && this.lastItem != null)
            {
                T currentFisrtItem = this.firstItem.Value;

                // check if there is one element in the list or not
                if (this.firstItem == this.lastItem)
                {
                    this.firstItem = null;
                    this.lastItem = null;
                }
                else
                {
                    this.firstItem = this.firstItem.Next;
                    this.firstItem.Previous = null;
                }

                return currentFisrtItem;
            }

            throw new InvalidOperationException("The list is empty");
        }

        public T RemoveLast()
        {
            // check if there are no elements in the list
            if (this.firstItem != null && this.lastItem != null)
            {
                T currentLastItem = this.lastItem.Value;

                // check if there is one element in the list or not
                if (this.firstItem == this.lastItem)
                {
                    this.firstItem = null;
                    this.lastItem = null;
                }
                else
                {
                    this.lastItem = this.lastItem.Previous;
                    this.lastItem.Next = null;
                }

                return currentLastItem;
            }

            throw new InvalidOperationException("The list is empty");
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentItem = this.firstItem;

            while (currentItem != null)
            {
                action(currentItem.Value);
                currentItem = currentItem.Next;
            }
        }

        public T[] ToArray()
        {
            T[] numbersToArray = new T[this.Count];

            ListNode<T> currentItem = this.firstItem;
            int countOfTransferedNumbers = 0;

            while (currentItem != null)
            {
                numbersToArray[countOfTransferedNumbers] = currentItem.Value;
                currentItem = currentItem.Next;
                countOfTransferedNumbers++;
            }

            return numbersToArray;
        }
    }
}
