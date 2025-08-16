namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rowsCount][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                double[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                // put the elements in the jagged array
                jaggedArray[row] = numbers;
            }

            // check the lengths of the arrays and multiply/divide their values
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                // multiply if their lengths are equal or divide if they are not equal
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }

            // execute commands (Add, Subtract or End)
            string[] commands;

            while (true)
            {
                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // check if the name of the command is "End"
                if (commands[0] == "End")
                {
                    // print the final state of the jagged array and stop the program
                    for (int i = 0; i < jaggedArray.Length; i++)
                    {
                        Console.WriteLine(string.Join(' ', jaggedArray[i]));
                    }

                    break;
                }

                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                // execute the command if the coordinates are valid
                if (row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length)
                {
                    if (commands[0] == "Add")
                    {
                        // add the value to the element with these coordinates
                        jaggedArray[row][col] += value;
                    }
                    else if (commands[0] == "Subtract")
                    {
                        // subtract the value from the element with these coordinates
                        jaggedArray[row][col] -= value;
                    }
                }
            }
        }
    }
}