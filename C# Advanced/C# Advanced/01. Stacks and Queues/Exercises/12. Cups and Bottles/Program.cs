namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> bottles = new Stack<int>();
            List<int> cupsValues = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bottlesValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (int bottle in bottlesValues)
            {
                bottles.Push(bottle);
            }
            
            int wastedLittersOfWater = 0;
            while (cupsValues.Count > 0 && bottles.Count > 0)
            {
                int bottle = bottles.Pop();
                int cup = cupsValues.First(); 
                cupsValues.RemoveAt(0);

                 //check if the bottle has more litters of water than the cup
                if (bottle >= cup)
                {
                    wastedLittersOfWater += bottle - cup;
                }
                else
                {
                    //return the cup to the list of cups with the new value
                    cup -= bottle;
                    cupsValues.Insert(0, cup); 
                }
            }

            // check if there are remained cups 
            if (cupsValues.Count == 0) 
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }               
            else 
            {
                Console.WriteLine($"Cups: {string.Join(' ', cupsValues)}");
            }
                
            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}"); 
        }
    }
}
