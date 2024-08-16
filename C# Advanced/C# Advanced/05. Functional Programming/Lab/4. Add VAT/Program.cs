namespace _4._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] pricesWithVAT = Console.ReadLine().Split(", ").Select(double.Parse).Select(x => x * 1.2).ToArray();
            foreach (double price in pricesWithVAT)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}