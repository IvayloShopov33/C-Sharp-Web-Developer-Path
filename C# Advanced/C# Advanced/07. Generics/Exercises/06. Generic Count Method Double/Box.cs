namespace _06._Generic_Count_Method_Double
{
    public class Box<T>
        where T : IComparable
    {
        private List<T> numbers;

        public Box(List<T> values)
        {
            this.numbers = values;
        }

        public int CalculateCountOfGreaterValues(T item)
        {
            int countOfGreaterValues = 0;
            foreach (T element in this.numbers)
            {
                if (element.CompareTo(item) > 0)
                {
                    countOfGreaterValues++;
                }
            }

            return countOfGreaterValues;
        }
    }
}
