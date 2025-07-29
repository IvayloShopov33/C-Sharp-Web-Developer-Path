namespace _7._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int[]> tourOfTheTruck = new Queue<int[]>();
            int pumpStation = int.Parse(Console.ReadLine());

            for (int i = 0; i < pumpStation; i++)
            {
                int[] pumpDetails = Console.ReadLine().Split().Select(int.Parse).ToArray();  
                int petrol = pumpDetails[0];
                int distance = pumpDetails[1];
                tourOfTheTruck.Enqueue(new int[] { petrol, distance });
            }
            
            int startIndex = 0;
            while (true)
            {
                int currentPetrol = 0;
                foreach (int[] details in tourOfTheTruck)
                {
                    int truckPetrol = details[0];
                    int truckDistance = details[1];

                    currentPetrol += truckPetrol;
                    currentPetrol -= truckDistance;

                    if (currentPetrol < 0)
                    {
                        tourOfTheTruck.Enqueue(tourOfTheTruck.Dequeue());
                        startIndex++;
                        break;
                    }
                }
                
                if (currentPetrol >= 0)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}