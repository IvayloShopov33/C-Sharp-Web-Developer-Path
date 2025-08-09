namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] numbers = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] valuesOfEachRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                numbers[row] = new int[valuesOfEachRow.Length];

                for (int col = 0; col < valuesOfEachRow.Length; col++)
                {
                    //put the elements in the jagged array
                    numbers[row][col] = valuesOfEachRow[col];
                }
            }

            string[] commands = Console.ReadLine().Split();
            while (true)
            {
                string action = commands[0];

                if (commands[0] == "END")
                {
                    //print the final jagged array
                    for (int r = 0; r < numbers.Length; r++)
                    {
                        for (int c = 0; c < numbers[r].Length; c++)
                        {
                            Console.Write(numbers[r][c] + " ");
                        }

                        Console.WriteLine();
                    }

                    //stop the program
                    break;
                }

                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                //check the command if it is "add" or "subtract"
                if (commands[0] == "Add")
                {
                    if (row >= 0 && row < numbers.Length && col >= 0 && col < numbers[row].Length)
                    {
                        numbers[row][col] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (commands[0] == "Subtract")
                {
                    if (row >= 0 && row < numbers.Length && col >= 0 && col < numbers[row].Length)
                    {
                        numbers[row][col] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }

                commands = Console.ReadLine().Split();
            }
        }
    }
}