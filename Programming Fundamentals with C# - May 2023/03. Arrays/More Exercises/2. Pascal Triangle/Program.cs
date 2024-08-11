using System;

namespace _2._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
           
                int n = int.Parse(Console.ReadLine());

                long[][] pascalTriangle = new long[n][];

                for (int i = 0; i < n; i++)
                {
                    pascalTriangle[i] = new long[i + 1];
                    pascalTriangle[i][0] = 1;

                    for (int j = 1; j < i; j++)
                    {
                        pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                    }

                    pascalTriangle[i][i] = 1;
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        Console.Write(pascalTriangle[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

    }


