namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixDimensions = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixDimensions, matrixDimensions];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    //put the elements in the matrix
                    matrix[row, col] = numbers[col];
                }
            }
            
            string[] coordinatesOfTheBombs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < coordinatesOfTheBombs.Length; i++)
            {
                int[] coordinates = coordinatesOfTheBombs[i].Split(',').Select(int.Parse).ToArray();
                int row = coordinates[0];
                int col = coordinates[1];
                
                //check if the bomb can explode
                if (matrix[row, col] > 0)
                {
                    int bomb = matrix[row, col];
                    matrix[row, col] = 0;
                    
                    //check where exactly the bomb is and decrease the value of the cells arount it
                    if (row > 0 && row < matrix.GetLength(0) - 1 && col > 0 && col < matrix.GetLength(1) - 1)
                    {
                        row--;
                        col--;
                        for (int j = row; j < row + 3; j++)
                        {
                            for (int k = col; k < col + 3; k++)
                            {
                                //check if the cell can explode
                                if (matrix[j, k] > 0)
                                {
                                    matrix[j, k] -= bomb;
                                }
                            }
                        }
                    }
                    else if (row == 0 && col > 0 && col < matrix.GetLength(1) - 1)
                    {
                        col--;
                        for (int j = row; j < row + 2; j++)
                        {
                            for (int k = col; k < col + 3; k++)
                            {
                                //check if the cell can explode
                                if (matrix[j, k] > 0)
                                {
                                    matrix[j, k] -= bomb;
                                }
                            }
                        }

                    }
                    else if (row > 0 && row < matrix.GetLength(0) - 1 && col == 0)
                    {
                        row--;
                        for (int j = row; j < row + 3; j++)
                        {
                            for (int k = col; k < col + 2; k++)
                            {
                                //check if the cell can explode
                                if (matrix[j, k] > 0)
                                {
                                    matrix[j, k] -= bomb;
                                }
                            }
                        }
                    }
                    else if (row == matrix.GetLength(0) - 1 && col > 0 && col < matrix.GetLength(1) - 1)
                    {
                        row--;
                        col--;
                        for (int j = row; j < row + 2; j++)
                        {
                            for (int k = col; k < col + 3; k++)
                            {
                                //check if the cell can explode
                                if (matrix[j, k] > 0)
                                {
                                    matrix[j, k] -= bomb;
                                }
                            }
                        }
                    }
                    else if (row > 0 && row < matrix.GetLength(0) - 1 && col == matrix.GetLength(1) - 1)
                    {
                        row--;
                        col--;
                        for (int j = row; j < row + 3; j++)
                        {
                            for (int k = col; k < col + 2; k++)
                            {
                                //check if the cell can explode
                                if (matrix[j, k] > 0)
                                {
                                    matrix[j, k] -= bomb;
                                }
                            }
                        }
                    }
                    else if (row == 0 && col == 0)
                    {
                        for (int j = row; j < row + 2; j++)
                        {
                            for (int k = col; k < col + 2; k++)
                            {
                                //check if the cell can explode
                                if (matrix[j, k] > 0)
                                {
                                    matrix[j, k] -= bomb;
                                }
                            }
                        }
                    }
                    else if (row == matrix.GetLength(0) - 1 && col == 0)
                    {
                        row--;
                        for (int j = row; j < row + 2; j++)
                        {
                            for (int k = col; k < col + 2; k++)
                            {
                                //check if the cell can explode
                                if (matrix[j, k] > 0)
                                {
                                    matrix[j, k] -= bomb;
                                }
                            }
                        }
                    }
                    else if (row == 0 && col == matrix.GetLength(1) - 1)
                    {
                        col--;
                        for (int j = row; j < row + 2; j++)
                        {
                            for (int k = col; k < col + 2; k++)
                            {
                                //check if the cell can explode
                                if (matrix[j, k] > 0)
                                {
                                    matrix[j, k] -= bomb;
                                }
                            }
                        }
                    }
                    else if (row == matrix.GetLength(0) - 1 && col == matrix.GetLength(1) - 1)
                    {
                        row--;
                        col--;
                        for (int j = row; j < row + 2; j++)
                        {
                            for (int k = col; k < col + 2; k++)
                            {
                                //check if the cell can explode
                                if (matrix[j, k] > 0)
                                {
                                    matrix[j, k] -= bomb;
                                }
                            }
                        }
                    }
                }
            }

            //check how many cells are alive (value>0) and calculate their sum
            int aliveCells = 0;
            int sumOfAlliveCells = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sumOfAlliveCells += matrix[row, col];
                    }
                }
            }

            //print the count of all allive cells, their sum and the final state of our matrix
            Console.WriteLine("Alive cells: " + aliveCells);
            Console.WriteLine("Sum: " + sumOfAlliveCells);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }              
                Console.WriteLine();
            }
        }
    }
}
