using System;
using System.Text.RegularExpressions;

namespace _3._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^[^\|\$%\.]*\%(?<customer>[A-Z][a-z]+)\%[^\|\$%\.]*\<(?<product>\w+)\>[^\|\$%\.]*\|(?<quantity>\d+)\|[^\|\$%\.]*?(?<price>\d+(\.\d+)?)\$[^\|\$%\.]*$";
            Regex regex = new Regex(pattern);
            string input;
            double totalSum = 0;
            while ((input=Console.ReadLine())!="end of shift")
            {
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    double pricePerUnit = double.Parse(match.Groups["price"].Value);
                    double sumOfOneProduct = quantity*pricePerUnit;
                    Console.WriteLine($"{customer}: {product} - {sumOfOneProduct:f2}");
                    totalSum += sumOfOneProduct;
                }
            }
            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
