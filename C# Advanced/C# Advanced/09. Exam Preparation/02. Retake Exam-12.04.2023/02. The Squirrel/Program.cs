namespace _02._The_Squirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[matrixSize, matrixSize];
            int currentRow = 0;
            int currentColumn = 0;
            int hazelnutsCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string matrixRow = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrixRow[col] == 's')
                    {
                        currentRow = row;
                        currentColumn = col;
                    }

                    matrix[row, col] = matrixRow[col];
                }
            }

            bool gameOver = false;
            for (int i = 0; i < directions.Length; i++)
            {
                string direction = directions[i];
                if (direction == "up")
                {
                    if (currentRow - 1 < 0)
                    {
                        Console.WriteLine("The squirrel is out of the field.");
                        gameOver = true;

                        break;
                    }

                    if (matrix[currentRow - 1, currentColumn] == 't')
                    {
                        Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                        gameOver = true;

                        break;
                    }

                    if (matrix[currentRow - 1, currentColumn] == 'h')
                    {
                        hazelnutsCount++;
                        if (hazelnutsCount == 3)
                        {
                            Console.WriteLine("Good job! You have collected all hazelnuts!");
                            gameOver = true;

                            break;
                        }
                    }

                    matrix[currentRow - 1, currentColumn] = 's';
                    matrix[currentRow, currentColumn] = '*';
                    currentRow--;
                }
                else if (direction == "down")
                {
                    if (currentRow + 1 == matrix.GetLength(0))
                    {
                        Console.WriteLine("The squirrel is out of the field.");
                        gameOver = true;

                        break;
                    }

                    if (matrix[currentRow + 1, currentColumn] == 't')
                    {
                        Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                        gameOver = true;

                        break;
                    }

                    if (matrix[currentRow + 1, currentColumn] == 'h')
                    {
                        hazelnutsCount++;
                        if (hazelnutsCount == 3)
                        {
                            Console.WriteLine("Good job! You have collected all hazelnuts!");
                            gameOver = true;

                            break;
                        }
                    }

                    matrix[currentRow + 1, currentColumn] = 's';
                    matrix[currentRow, currentColumn] = '*';
                    currentRow++;
                }
                else if (direction == "right")
                {
                    if (currentColumn + 1 == matrix.GetLength(1))
                    {
                        Console.WriteLine("The squirrel is out of the field.");
                        gameOver = true;

                        break;
                    }

                    if (matrix[currentRow, currentColumn + 1] == 't')
                    {
                        Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                        gameOver = true;

                        break;
                    }

                    if (matrix[currentRow, currentColumn + 1] == 'h')
                    {
                        hazelnutsCount++;
                        if (hazelnutsCount == 3)
                        {
                            Console.WriteLine("Good job! You have collected all hazelnuts!");
                            gameOver = true;

                            break;
                        }
                    }

                    matrix[currentRow, currentColumn + 1] = 's';
                    matrix[currentRow, currentColumn] = '*';
                    currentColumn++;
                }
                else if (direction == "left")
                {
                    if (currentColumn - 1 < 0)
                    {
                        Console.WriteLine("The squirrel is out of the field.");
                        gameOver = true;

                        break;
                    }

                    if (matrix[currentRow, currentColumn - 1] == 't')
                    {
                        Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                        gameOver = true;

                        break;
                    }

                    if (matrix[currentRow, currentColumn - 1] == 'h')
                    {
                        hazelnutsCount++;
                        if (hazelnutsCount == 3)
                        {
                            Console.WriteLine("Good job! You have collected all hazelnuts!");
                            gameOver = true;

                            break;
                        }
                    }

                    matrix[currentRow, currentColumn - 1] = 's';
                    matrix[currentRow, currentColumn] = '*';
                    currentColumn--;
                }
            }

            if (!gameOver)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }

            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
        }
    }
}