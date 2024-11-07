using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            //монети от 200 ст, 100 ст, 50 ст., 20 ст,, 10 ст, 5 ст, 2ст, 1 ст
            double changeToReturn = double.Parse(Console.ReadLine()) * 100;
            int count = 0;
            
            while (changeToReturn > 0)
            {
                if (changeToReturn >= 200)
                    changeToReturn -= 200;
                else if (changeToReturn < 200 && changeToReturn >= 100)
                    changeToReturn -= 100;
                else if (changeToReturn < 100 && changeToReturn >= 50)
                    changeToReturn -= 50;
                else if (changeToReturn < 50 && changeToReturn >= 20)
                    changeToReturn -= 20;
                else if (changeToReturn < 20 && changeToReturn >= 10)
                    changeToReturn -= 10;
                else if (changeToReturn < 10 && changeToReturn >= 5)
                    changeToReturn -= 5;
                else if (changeToReturn < 5 && changeToReturn >= 2)
                    changeToReturn -= 2;
                else if (changeToReturn < 2 && changeToReturn >= 1)
                    changeToReturn -= 1;
                else
                {
                    changeToReturn = 0;
                    break;
                }
                
                count++;
            }
            
            Console.WriteLine(count);
        }
    }
}
