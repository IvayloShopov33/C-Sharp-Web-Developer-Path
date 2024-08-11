using System;
using System.Linq;


namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            short fieldLength = short.Parse(Console.ReadLine());
            int[] bugIndexesOnTheField = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] field = new int[fieldLength];

            for (int i = 0; i < bugIndexesOnTheField.Length; i++) // нанасяне на калинките на полето
            {
                if (bugIndexesOnTheField[i] >= 0 && bugIndexesOnTheField[i] < field.Length)
                {
                    field[bugIndexesOnTheField[i]] = 1;

                }
            }

            string input =string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] index = input.Split(' ');
                int ladybugIndex = int.Parse(index[0]);
                string direction = index[1];
                int flyLength = int.Parse(index[2]);

                if (ladybugIndex<0 || ladybugIndex>field.Length-1 || field[ladybugIndex]==0)
                {
                    continue;
                }

                field[ladybugIndex] = 0;
                if (direction == "right")
                {
                    int landbugIndex = ladybugIndex + flyLength;

                    if (landbugIndex > field.Length - 1)
                    {
                        continue;
                    }

                    if (field[landbugIndex] == 1)
                    {
                        while (field[landbugIndex]==1)
                        {
                            landbugIndex += flyLength;

                            if (landbugIndex>field.Length-1)
                            {
                                break;
                            }
                        }
                    }

                    if (landbugIndex<=field.Length-1)
                    {
                        field[landbugIndex] = 1;
                    }

                }
                else if (direction == "left")
                {
                    int landbugIndex = ladybugIndex - flyLength;

                    if (landbugIndex < 0)
                    {
                        continue;
                    }

                    if (field[landbugIndex]==1)
                    {
                        while (field[landbugIndex]==1)
                        {
                            landbugIndex -= flyLength;
                            if (landbugIndex<0)
                            {
                                break;
                            }
                        }
                    }

                    if (landbugIndex>=0)
                    {
                        field[landbugIndex] = 1;
                    }
                }
            }

            Console.WriteLine(String.Join(' ', field));
        }
    }
}