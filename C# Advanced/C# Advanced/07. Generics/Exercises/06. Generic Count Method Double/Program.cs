namespace _06._Generic_Count_Method_Double
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();
            Box<double> box = new Box<double>(numbers);

            int countOfNumbers = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfNumbers; i++)
            {
                double number = double.Parse(Console.ReadLine());
                numbers.Add(number);
            }

            double numberToCompare = double.Parse(Console.ReadLine());
            int result = box.CalculateCountOfGreaterValues(numberToCompare);
            Console.WriteLine(result);
        }
    }
}