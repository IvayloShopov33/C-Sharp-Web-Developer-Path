namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    // put the elements in the matrix
                    matrix[row, col] = numbers[col];
                }
            }

            // calculate the maximum sum of a 3X3 submatrix
            int maxSum = int.MinValue;
            int rowsOfTheSubMatrix = 0;
            int colsOfTheSubMatrix = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = 0;

                    // calculate the sum of the current 3X3 submatrix
                    for (int i = row; i < row + 3; i++)
                    {
                        for (int j = col; j < col + 3; j++)
                        {
                            currentSum += matrix[i, j];
                        }
                    }

                    // check if the current sum is greater than the maximum sum
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowsOfTheSubMatrix = row;
                        colsOfTheSubMatrix = col;
                    }
                }
            }

            // print the maximum sum of the 3X3 submatrix and itself
            Console.WriteLine("Sum = " + maxSum);

            for (int row = rowsOfTheSubMatrix; row < rowsOfTheSubMatrix + 3; row++)
            {
                for (int col = colsOfTheSubMatrix; col < colsOfTheSubMatrix + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}