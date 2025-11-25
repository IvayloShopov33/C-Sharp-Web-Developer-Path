namespace _01._Monster_Extermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> monstersArmors = new();
            Stack<int> soldiersStrengths = new();

            List<int> monsters = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> soldiers = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            foreach (int monster in monsters)
            {
                monstersArmors.Enqueue(monster);
            }

            foreach (int soldier in soldiers)
            {
                soldiersStrengths.Push(soldier);
            }

            int killedMonstersCount = 0;
            while (soldiersStrengths.Count > 0 && monstersArmors.Count > 0)
            {
                int strength = soldiersStrengths.Pop();
                int armor = monstersArmors.Dequeue();

                if (strength >= armor)
                {
                    int remainedStrength = strength - armor;
                    if (remainedStrength != 0)
                    {
                        if (soldiersStrengths.Count > 0)
                        {
                            int newStrength = soldiersStrengths.Pop() + remainedStrength;
                            soldiersStrengths.Push(newStrength);
                        }
                        else
                        {
                            soldiersStrengths.Push(remainedStrength);
                        }
                    }

                    killedMonstersCount++;
                }
                else
                {
                    int newArmor = armor - strength;
                    monstersArmors.Enqueue(newArmor);
                }
            }

            if (monstersArmors.Count == 0)
            {
                Console.WriteLine("All monsters have been killed!");
            }

            if (soldiersStrengths.Count == 0)
            {
                Console.WriteLine("The soldier has been defeated.");
            }

            Console.WriteLine($"Total monsters killed: {killedMonstersCount}");
        }
    }
}