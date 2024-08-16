namespace _05._Generic_Count_Method_String
{
    public class Box<T>
        where T : IComparable
    {
        private List<T> items;

        public Box(List<T> input)
        {
            this.items = input;
        }

        public int CalculateCountOfGreaterElements(T element)
        {
            int countOfGreaterElements = 0;
            foreach (T item in this.items)
            {
                if (item.CompareTo(element) > 0)
                {
                    countOfGreaterElements++;
                }
            }

            return countOfGreaterElements;
        }
    }
}
