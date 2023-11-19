namespace CustomRandomList
{
    public class RandomList<T> : List<T>
    {
        private Random random;

        public RandomList()
        {
            this.random = new Random();
        }

        public T RandomString()
        {
            int randomIndex = random.Next(0, base.Count);
            T element = base[randomIndex];
            base.RemoveAt(randomIndex);

            return element;
        }
    }
}
