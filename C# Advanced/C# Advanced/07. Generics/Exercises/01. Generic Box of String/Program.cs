namespace _01._Generic_Box_of_String
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int stringsCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= stringsCount; i++)
            {
                string input = Console.ReadLine();

                Box<string> box = new Box<string>(input);
                boxes.Add(box);
            }

            foreach (var item in boxes)
            {
                Console.WriteLine(item);
            }
        }
    }
}