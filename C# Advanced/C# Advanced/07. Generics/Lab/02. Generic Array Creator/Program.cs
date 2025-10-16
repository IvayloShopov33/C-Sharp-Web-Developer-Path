namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] names = ArrayCreator.Create<string>(5, "John");
            int[] numbers = ArrayCreator.Create<int>(8, 15);

            Console.WriteLine(string.Join(", ", names));
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}