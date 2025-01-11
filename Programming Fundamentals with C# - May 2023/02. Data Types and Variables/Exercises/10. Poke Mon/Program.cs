using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine()); // N
            int distanceBetweenTargets = int.Parse(Console.ReadLine()); // M
            int exhaustionFactor = int.Parse(Console.ReadLine()); // Y
            
            int pokedTargets = 0;
            int pokePowerCopy = pokePower;
            
            while (pokePower >= distanceBetweenTargets)
            {
                pokePower -= distanceBetweenTargets;
                
                if (pokePower == pokePowerCopy / 2 && exhaustionFactor != 0)
                {
                    pokePower /= exhaustionFactor;
                }
                
                pokedTargets++;
            }
            
            Console.WriteLine(pokePower);
            Console.WriteLine(pokedTargets);
        }
    }
}
