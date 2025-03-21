using System;

namespace _01._Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            double sumOfPricesWithoutTaxes = 0;
            double sumOfPricesWithTaxes = 0;
            double taxes = 0;
            double price = 0;
            
            while (input != "special" && input != "regular")
            {
                price = double.Parse(input);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    
                    continue;
                }
                
                sumOfPricesWithoutTaxes += price;
                taxes += price * 0.2;
                price += price * 0.2;
                sumOfPricesWithTaxes += price;
                
                input = Console.ReadLine();
            }

            if (input == "special")
            {
                sumOfPricesWithTaxes -= sumOfPricesWithTaxes * 0.1;
            }

            if (sumOfPricesWithoutTaxes == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {sumOfPricesWithoutTaxes:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {sumOfPricesWithTaxes:f2}$");
            }
        }
    }
}
