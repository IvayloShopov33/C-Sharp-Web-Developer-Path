using System;

namespace _11._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            decimal sum = 0;
            
            for (int i = 0; i < orders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());
                
                decimal ordersPrice = (days * capsulesCount) * pricePerCapsule;
                Console.WriteLine($"The price for the coffee is: ${ordersPrice:F2}");
                
                sum += ordersPrice;
            }
            
            Console.WriteLine($"Total: ${sum:F2}");
        }
    }
}
