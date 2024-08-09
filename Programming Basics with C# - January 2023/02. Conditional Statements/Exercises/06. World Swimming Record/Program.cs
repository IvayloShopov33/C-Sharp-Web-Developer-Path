using System;

namespace _06._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());
            double delay = Math.Floor(length / 15) * 12.5;
            double recordByIvan = length * timePerMeter + delay;
            if (recordByIvan<worldRecord)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {recordByIvan:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {Math.Abs(recordByIvan-worldRecord):f2} seconds slower.");
            }
        }
    }
}
