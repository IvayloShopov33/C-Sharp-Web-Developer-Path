using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            //вход от конзолата-spend/save; кеша, който харчи или спестява, брояч на общо изминатите дни, брояч на предните дни, в които харчи
            double neededMoney = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            string input;
            double money;
            int daysCount = 0;
            int spendCount = 0;
            while (availableMoney<neededMoney)
            {
                input = Console.ReadLine();
                money = double.Parse(Console.ReadLine());
                daysCount++;
                if (input=="save")
                {
                    availableMoney += money;
                    spendCount = 0; //нулиране на брояч
                }
                else
                {
                    spendCount++;
                    if (spendCount==5)
                    {
                        Console.WriteLine($"You can't save the money.");
                        Console.WriteLine(daysCount);
                        break;
                    }
                    availableMoney -= money;
                    if (availableMoney<0)
                    {
                        availableMoney = 0;
                    }
                }
            }
            if (availableMoney>=neededMoney)
            {
                Console.WriteLine($"You saved the money for {daysCount} days.");
            }
        }
    }
}
