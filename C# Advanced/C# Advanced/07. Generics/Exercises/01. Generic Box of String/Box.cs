namespace _01._Generic_Box_of_String
{
    public class Box<T>
    {
        private T item;

        public Box(T input)
        {
            this.item = input;
        }

        public override string ToString()
        {
            Type type = this.item.GetType();
            string output = $"{type}: {this.item}";

            return output;
        }
    }
}
