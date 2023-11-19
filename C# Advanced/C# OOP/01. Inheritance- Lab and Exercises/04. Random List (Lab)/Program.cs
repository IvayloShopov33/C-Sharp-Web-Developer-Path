namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList<string> list = new RandomList<string>
            {
                "1",
                "2",
                "3"
            };

            list.RandomString();

            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.Count);
        }
    }
}