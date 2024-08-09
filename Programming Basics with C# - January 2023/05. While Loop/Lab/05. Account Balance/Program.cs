using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            double accountBalance = 0;
            string input=Console.ReadLine();
            while (input!="NoMoreMoney")
            {
                double depositAmount = double.Parse(input);
                if (depositAmount<0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                accountBalance += depositAmount;
                Console.WriteLine($"Increase: {depositAmount:f2}");
                input = Console.ReadLine();
            }
            //if (input=="NoMoreMoney")
            //{
            //    end command
            //}
            //else
            //{
            //    negative amount
            //}
            Console.WriteLine($"Total: {accountBalance:f2}");
        }
    }
}
