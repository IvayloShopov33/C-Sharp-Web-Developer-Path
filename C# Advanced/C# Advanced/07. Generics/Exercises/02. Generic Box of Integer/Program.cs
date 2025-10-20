namespace _02._Generic_Box_of_Integer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxesOfIntegers = new List<Box<int>>();
            int numbersCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(number);
                boxesOfIntegers.Add(box);
            }

            foreach (Box<int> item in boxesOfIntegers)
            {
                Console.WriteLine(item);
            }
        }
    }
}