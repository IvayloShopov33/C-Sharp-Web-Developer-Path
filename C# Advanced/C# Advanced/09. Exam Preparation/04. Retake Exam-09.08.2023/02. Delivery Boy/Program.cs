namespace _02._Delivery_Boy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[matrixDimensions[0], matrixDimensions[1]];
            int initialRow = 0, initialCol = 0, currentRow = 0, currentColumn = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (rowInput[col] == 'B')
                    {
                        initialRow = row;
                        initialCol = col;
                        currentRow = initialRow;
                        currentColumn = initialCol;
                    }

                    matrix[row, col] = rowInput[col];
                }
            }

            bool gameOver = false;
            while (!gameOver)
            {
                string direction = Console.ReadLine();
                if (direction == "up")
                {
                    if (currentRow - 1 < 0)
                    {
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        matrix[initialRow, initialCol] = ' ';
                        gameOver = true;
                    }
                    else
                    {
                        if (matrix[currentRow - 1, currentColumn] != '*')
                        {
                            if (matrix[currentRow - 1, currentColumn] == 'P')
                            {
                                Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                                matrix[currentRow - 1, currentColumn] = 'R';
                                matrix[currentRow, currentColumn] = '.';
                                currentRow--;
                            }
                            else if (matrix[currentRow - 1, currentColumn] == 'A')
                            {
                                Console.WriteLine("Pizza is delivered on time! Next order...");
                                gameOver = true;
                                matrix[currentRow - 1, currentColumn] = 'P';
                                matrix[currentRow, currentColumn] = '.';
                                matrix[initialRow, initialCol] = 'B';
                            }
                            else
                            {
                                if (matrix[currentRow, currentColumn] != 'R')
                                {
                                    matrix[currentRow, currentColumn] = '.';
                                }

                                currentRow--;
                            }
                        }
                    }
                }
                else if (direction == "down")
                {
                    if (currentRow + 1 >= matrix.GetLength(0))
                    {
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        matrix[initialRow, initialCol] = ' ';
                        gameOver = true;
                    }
                    else
                    {
                        if (matrix[currentRow + 1, currentColumn] != '*')
                        {
                            if (matrix[currentRow + 1, currentColumn] == 'P')
                            {
                                Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                                matrix[currentRow + 1, currentColumn] = 'R';
                                matrix[currentRow, currentColumn] = '.';
                                currentRow++;
                            }
                            else if (matrix[currentRow + 1, currentColumn] == 'A')
                            {
                                Console.WriteLine("Pizza is delivered on time! Next order...");
                                gameOver = true;
                                matrix[currentRow + 1, currentColumn] = 'P';
                                matrix[currentRow, currentColumn] = '.';
                                matrix[initialRow, initialCol] = 'B';
                            }
                            else
                            {
                                if (matrix[currentRow, currentColumn] != 'R')
                                {
                                    matrix[currentRow, currentColumn] = '.';
                                }

                                currentRow++;
                            }
                        }
                    }
                }
                else if (direction == "right")
                {
                    if (currentColumn + 1 >= matrix.GetLength(1))
                    {
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        matrix[initialRow, initialCol] = ' ';
                        gameOver = true;
                    }
                    else
                    {
                        if (matrix[currentRow, currentColumn + 1] != '*')
                        {
                            if (matrix[currentRow, currentColumn + 1] == 'P')
                            {
                                Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                                matrix[currentRow, currentColumn + 1] = 'R';
                                matrix[currentRow, currentColumn] = '.';
                                currentColumn++;
                            }
                            else if (matrix[currentRow, currentColumn + 1] == 'A')
                            {
                                Console.WriteLine("Pizza is delivered on time! Next order...");
                                gameOver = true;
                                matrix[currentRow, currentColumn + 1] = 'P';
                                matrix[currentRow, currentColumn] = '.';
                                matrix[initialRow, initialCol] = 'B';
                            }
                            else
                            {
                                if (matrix[currentRow, currentColumn] != 'R')
                                {
                                    matrix[currentRow, currentColumn] = '.';
                                }

                                currentColumn++;
                            }
                        }
                    }
                }
                else if (direction == "left")
                {
                    if (currentColumn - 1 < 0)
                    {
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        matrix[initialRow, initialCol] = ' ';
                        gameOver = true;
                    }
                    else
                    {
                        if (matrix[currentRow, currentColumn - 1] != '*')
                        {
                            if (matrix[currentRow, currentColumn - 1] == 'P')
                            {
                                Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                                matrix[currentRow, currentColumn - 1] = 'R';
                                matrix[currentRow, currentColumn] = '.';
                                currentColumn--;
                            }
                            else if (matrix[currentRow, currentColumn - 1] == 'A')
                            {
                                Console.WriteLine("Pizza is delivered on time! Next order...");
                                gameOver = true;
                                matrix[currentRow, currentColumn - 1] = 'P';
                                matrix[currentRow, currentColumn] = '.';
                                matrix[initialRow, initialCol] = 'B';
                            }
                            else
                            {
                                if (matrix[currentRow, currentColumn] != 'R')
                                {
                                    matrix[currentRow, currentColumn] = '.';
                                }

                                currentColumn--;
                            }
                        }
                    }
                }
            }

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