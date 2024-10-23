using System;

namespace _07._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            int peopleInGroup;
            int musala = 0;
            int monblan = 0;
            int kilimandgaro = 0;
            int k2 = 0;
            int everest = 0;
            
            for (int i = 1; i <= groups; i++)
            {
                peopleInGroup= int.Parse(Console.ReadLine());
                if (peopleInGroup <= 5)
                    musala += peopleInGroup;
                else if (peopleInGroup <= 12)
                    monblan += peopleInGroup;
                else if (peopleInGroup <= 25)
                    kilimandgaro += peopleInGroup;
                else if (peopleInGroup <= 40)
                    k2 += peopleInGroup;
                else
                    everest += peopleInGroup;
            }
            
            int allPeople = musala + monblan + kilimandgaro + k2 + everest;
            Console.WriteLine($"{(double)musala / allPeople * 100:f2}%");
            Console.WriteLine($"{(double)monblan / allPeople * 100:f2}%");
            Console.WriteLine($"{(double)kilimandgaro / allPeople * 100:f2}%");
            Console.WriteLine($"{(double)k2 / allPeople * 100:f2}%");
            Console.WriteLine($"{(double)everest / allPeople * 100:f2}%");
        }
    }
}
