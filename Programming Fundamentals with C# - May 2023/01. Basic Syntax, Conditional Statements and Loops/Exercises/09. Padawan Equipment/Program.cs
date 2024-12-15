using System;

namespace _9._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            float money = float.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            float sabersPrice = float.Parse(Console.ReadLine());
            float robesPrice = float.Parse(Console.ReadLine());
            float beltsPrice = float.Parse(Console.ReadLine());
            
            int sabersAdd = (int)Math.Ceiling(studentsCount + 0.1 * studentsCount);
            int beltsfree = 0;
            
            for (int i = 0; i <= studentsCount; i += 6)
            {
                if (i != 0)
                {
                    beltsfree++;
                }
            }
            
            int beltsNotFree = studentsCount - beltsfree;
            double allPrice = (sabersPrice * sabersAdd) + (robesPrice * studentsCount) + (beltsPrice * beltsNotFree);
            
            if (allPrice <= money)
                Console.WriteLine($"The money is enough - it would cost {allPrice:f2}lv.");
            else
                Console.WriteLine($"John will need {allPrice-money:f2}lv more.");
        }
    }
}
