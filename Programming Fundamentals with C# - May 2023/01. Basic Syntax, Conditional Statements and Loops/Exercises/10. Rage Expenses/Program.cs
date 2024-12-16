using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            float headsetPrice = float.Parse(Console.ReadLine());
            float mousePrice = float.Parse(Console.ReadLine());
            float keyboardPrice = float.Parse(Console.ReadLine());
            float displayPrice = float.Parse(Console.ReadLine());
            
            int headsetCount = lostGamesCount / 2;
            int mouseCount = lostGamesCount / 3;
            int keyboardCount = lostGamesCount / 6;
            int displayCount = keyboardCount / 2;
            
            double expenses = headsetPrice * headsetCount + mousePrice * mouseCount + keyboardPrice * keyboardCount + displayPrice * displayCount;
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
