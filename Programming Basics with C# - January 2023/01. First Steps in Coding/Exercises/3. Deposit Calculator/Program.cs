using System;

namespace _03._Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            double rate = double.Parse(Console.ReadLine()) / 100;
            
            double sum = deposit + month * ((deposit * rate) / 12);
            Console.WriteLine(sum);
        }
    }
}
