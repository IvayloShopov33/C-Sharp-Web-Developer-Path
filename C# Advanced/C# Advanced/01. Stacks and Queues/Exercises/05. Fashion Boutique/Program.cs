namespace _5._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>();
            int[] arrayOfClothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacityOfARack = int.Parse(Console.ReadLine());
            int initialCapacityOfARack = capacityOfARack;
            foreach (int garment in arrayOfClothes)
            {
                clothes.Push(garment);
            }
            
            int countOfRacks = 1;
            foreach (int item in clothes.ToList())
            {
                //check if the item is greater, equal or smaller than the capacity of the rack
                if (item > capacityOfARack)
                {
                    countOfRacks++;
                    capacityOfARack = initialCapacityOfARack - item;
                }
                else if (item == capacityOfARack)
                {
                    capacityOfARack = initialCapacityOfARack;
                    if (clothes.Count > 1)
                        countOfRacks++;
                }
                else
                {
                    capacityOfARack -= item;
                }
                
                clothes.Pop();
            }
            
            if (clothes.Count == 0)
                Console.WriteLine(countOfRacks);
        }
    }
}
