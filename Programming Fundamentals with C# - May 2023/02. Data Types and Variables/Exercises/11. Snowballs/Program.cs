using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowballsCount = int.Parse(Console.ReadLine());
            
            BigInteger biggestSnowballValue = 0;
            int biggestSnowballSnow = 0;
            int biggestSnowballTime = 0;
            int biggestSnowballQuality = 0;
            
            for (int i = 0; i < snowballsCount; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                
                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                if (biggestSnowballValue < snowballValue)
                {
                    biggestSnowballValue = snowballValue;
                    biggestSnowballSnow = snowballSnow;
                    biggestSnowballTime = snowballTime;
                    biggestSnowballQuality = snowballQuality;
                }
            }
            
            Console.WriteLine($"{biggestSnowballSnow} : {biggestSnowballTime} = {biggestSnowballValue} ({biggestSnowballQuality})");
        }
    }
}
