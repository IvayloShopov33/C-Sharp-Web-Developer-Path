using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distancesToPokemon = Console.ReadLine().Split().Select(int.Parse).ToList();
            int index;
            int sumOfRemovedElements = 0;
            
            while (distancesToPokemon.Count > 0)
            {
                index = int.Parse(Console.ReadLine());
                if (index >= 0 && index < distancesToPokemon.Count)
                {
                    int copyElement = distancesToPokemon[index];
                    distancesToPokemon.RemoveAt(index);
                    sumOfRemovedElements += copyElement;
                    
                    for (int i = 0; i < distancesToPokemon.Count; i++)
                    {
                        if (distancesToPokemon[i] <= copyElement)
                        {
                            distancesToPokemon[i] += copyElement;
                        }
                        else
                        {
                            distancesToPokemon[i] -= copyElement;
                        }
                    }
                }
                else if (index < 0)
                {
                    int copyElement = distancesToPokemon[distancesToPokemon.Count - 1];
                    int removedElement = distancesToPokemon[0];
                    sumOfRemovedElements += removedElement;
                    
                    distancesToPokemon.RemoveAt(0);
                    distancesToPokemon.Insert(0, copyElement);
                    
                    for (int i = 0; i < distancesToPokemon.Count; i++)
                    {
                        if (distancesToPokemon[i] <= removedElement)
                        {
                            distancesToPokemon[i] += removedElement;
                        }
                        else
                        {
                            distancesToPokemon[i] -= removedElement;
                        }
                    }
                }
                else if (index > distancesToPokemon.Count - 1)
                {
                    int copyElement = distancesToPokemon[0];
                    int removedElement = distancesToPokemon[distancesToPokemon.Count - 1];
                    sumOfRemovedElements += removedElement;
                    
                    distancesToPokemon.RemoveAt(distancesToPokemon.Count - 1);
                    distancesToPokemon.Insert(distancesToPokemon.Count, copyElement);
                    
                    for (int i = 0; i < distancesToPokemon.Count; i++)
                    {
                        if (distancesToPokemon[i] <= removedElement)
                        {
                            distancesToPokemon[i] += removedElement;
                        }
                        else
                        {
                            distancesToPokemon[i] -= removedElement;
                        }
                    }
                }               
            }
            
            Console.WriteLine(sumOfRemovedElements);
        }
    }
}
