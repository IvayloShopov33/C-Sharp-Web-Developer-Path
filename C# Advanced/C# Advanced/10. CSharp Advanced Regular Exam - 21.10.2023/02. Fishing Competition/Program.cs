namespace _02._Fishing_Competition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixDimension = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixDimension, matrixDimension];
            int currentRow = 0, currentColumn = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (rowInput[col] == 'S')
                    {
                        currentRow = row;
                        currentColumn = col;
                    }

                    matrix[row, col] = rowInput[col];
                }
            }

            int nextRow = 0, nextColumn = 0;
            int collectedTonsOfFish = 0;
            string direction = Console.ReadLine();

            while (direction != "collect the nets")
            {
                nextRow = currentRow;
                nextColumn = currentColumn;

                if (direction == "up")
                {
                    nextRow--;
                    if (nextRow < 0)
                    {
                        nextRow = matrix.GetLength(0) - 1;
                    }
                }
                else if (direction == "down")
                {
                    nextRow++;
                    if (nextRow == matrix.GetLength(0))
                    {
                        nextRow = 0;
                    }
                }
                else if (direction == "right")
                {
                    nextColumn++;
                    if (nextColumn == matrix.GetLength(1))
                    {
                        nextColumn = 0;
                    }
                }
                else if (direction == "left")
                {
                    nextColumn--;
                    if (nextColumn < 0)
                    {
                        nextColumn = matrix.GetLength(1) - 1;
                    }
                }

                if (matrix[nextRow, nextColumn] == 'W')
                {
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{nextRow},{nextColumn}]");
                    Environment.Exit(0);
                }

                if (char.IsDigit(matrix[nextRow, nextColumn]))
                {
                    collectedTonsOfFish += int.Parse(matrix[nextRow, nextColumn].ToString());
                }

                matrix[currentRow, currentColumn] = '-';
                currentRow = nextRow;
                currentColumn = nextColumn;

                direction = Console.ReadLine();
            }

            if (collectedTonsOfFish >= 20)
            {
                Console.WriteLine("Success! You managed to reach the quota!");
                Console.WriteLine($"Amount of fish caught: {collectedTonsOfFish} tons.");
            }
            else
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - collectedTonsOfFish} tons of fish more.");

                if (collectedTonsOfFish > 0)
                {
                    Console.WriteLine($"Amount of fish caught: {collectedTonsOfFish} tons.");
                }
            }

            matrix[currentRow, currentColumn] = 'S';
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}