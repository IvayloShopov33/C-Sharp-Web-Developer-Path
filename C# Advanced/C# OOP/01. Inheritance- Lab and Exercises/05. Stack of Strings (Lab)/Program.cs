namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();
            Console.WriteLine(stackOfStrings.IsEmpty());
            List<string> items = new List<string>()
            {
                "1",
                "2",
                "3"
            };

            stackOfStrings.AddRange(items);
            Console.WriteLine(string.Join(", ", stackOfStrings));
        }
    }
}