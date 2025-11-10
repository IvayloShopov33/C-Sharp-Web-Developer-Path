namespace _02._Mouse_In_The_Kitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            char[,] matrix = new char[matrixSizes[0], matrixSizes[1]];
            
            int currentRow = 0;
            int currentColumn = 0;
            int cheeseCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputGameRows = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (inputGameRows[col] == 'M')
                    {
                        currentRow = row;
                        currentColumn = col;
                    }
                    else if (inputGameRows[col] == 'C')
                    {
                        cheeseCount++;
                    }

                    matrix[row, col] = inputGameRows[col];
                }
            }

            bool gameOver = false;
            string direction;
            
            while (true)
            {
                direction = Console.ReadLine().ToLower();
                if (direction == "danger")
                {
                    if (cheeseCount > 0 && !gameOver)
                    {
                        Console.WriteLine("Mouse will come back later!");
                    }

                    break;
                }

                if (direction == "up" && !gameOver)
                {
                    if (currentRow - 1 == -1)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        gameOver = true;
                    }
                    else
                    {
                        if (matrix[currentRow - 1, currentColumn] != '@')
                        {
                            if (matrix[currentRow - 1, currentColumn] == 'C')
                            {
                                cheeseCount--;
                                matrix[currentRow - 1, currentColumn] = 'M';
                                matrix[currentRow, currentColumn] = '*';

                                if (cheeseCount == 0)
                                {
                                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                    gameOver = true;
                                }
                            }
                            else if (matrix[currentRow - 1, currentColumn] == 'T')
                            {
                                matrix[currentRow - 1, currentColumn] = 'M';
                                matrix[currentRow, currentColumn] = '*';
                                
                                Console.WriteLine("Mouse is trapped!");
                                gameOver = true;
                            }
                            else
                            {
                                matrix[currentRow - 1, currentColumn] = 'M';
                                matrix[currentRow, currentColumn] = '*';
                            }

                            currentRow--;
                        }
                    }
                }
                else if (direction == "down" && !gameOver)
                {
                    if (currentRow + 1 == matrix.GetLength(0))
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        gameOver = true;
                    }
                    else
                    {
                        if (matrix[currentRow + 1, currentColumn] != '@')
                        {
                            if (matrix[currentRow + 1, currentColumn] == 'C')
                            {
                                cheeseCount--;
                                matrix[currentRow + 1, currentColumn] = 'M';
                                matrix[currentRow, currentColumn] = '*';

                                if (cheeseCount == 0)
                                {
                                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                    gameOver = true;
                                }
                            }
                            else if (matrix[currentRow + 1, currentColumn] == 'T')
                            {
                                matrix[currentRow + 1, currentColumn] = 'M';
                                matrix[currentRow, currentColumn] = '*';
                                
                                Console.WriteLine("Mouse is trapped!");
                                gameOver = true;
                            }
                            else
                            {
                                matrix[currentRow + 1, currentColumn] = 'M';
                                matrix[currentRow, currentColumn] = '*';
                            }

                            currentRow++;
                        }
                    }
                }
                else if (direction == "right" && !gameOver)
                {
                    if (currentColumn + 1 == matrix.GetLength(1))
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        gameOver = true;
                    }
                    else
                    {
                        if (matrix[currentRow, currentColumn + 1] != '@')
                        {
                            if (matrix[currentRow, currentColumn + 1] == 'C')
                            {
                                cheeseCount--;
                                matrix[currentRow, currentColumn + 1] = 'M';
                                matrix[currentRow, currentColumn] = '*';

                                if (cheeseCount == 0)
                                {
                                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                    gameOver = true;
                                }
                            }
                            else if (matrix[currentRow, currentColumn + 1] == 'T')
                            {
                                matrix[currentRow, currentColumn + 1] = 'M';
                                matrix[currentRow, currentColumn] = '*';
                                
                                Console.WriteLine("Mouse is trapped!");
                                gameOver = true;
                            }
                            else
                            {
                                matrix[currentRow, currentColumn + 1] = 'M';
                                matrix[currentRow, currentColumn] = '*';
                            }

                            currentColumn++;
                        }
                    }
                }
                else if (direction == "left" && !gameOver)
                {
                    if (currentColumn - 1 == -1)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        gameOver = true;
                    }
                    else
                    {
                        if (matrix[currentRow, currentColumn - 1] != '@')
                        {
                            if (matrix[currentRow, currentColumn - 1] == 'C')
                            {
                                cheeseCount--;
                                matrix[currentRow, currentColumn - 1] = 'M';
                                matrix[currentRow, currentColumn] = '*';

                                if (cheeseCount == 0)
                                {
                                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                    gameOver = true;
                                }
                            }
                            else if (matrix[currentRow, currentColumn - 1] == 'T')
                            {
                                matrix[currentRow, currentColumn - 1] = 'M';
                                matrix[currentRow, currentColumn] = '*';
                                
                                Console.WriteLine("Mouse is trapped!");
                                gameOver = true;
                            }
                            else
                            {
                                matrix[currentRow, currentColumn - 1] = 'M';
                                matrix[currentRow, currentColumn] = '*';
                            }

                            currentColumn--;
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
