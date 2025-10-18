namespace _02._Generic_Box_of_Integer
{
    public class Box<T>
    {
        private T element;

        public Box(T element)
        {
            this.element = element;
        }

        public override string ToString()
        {
            Type type = typeof(T);

            return $"{type}: {this.element}";
        }
    }
}