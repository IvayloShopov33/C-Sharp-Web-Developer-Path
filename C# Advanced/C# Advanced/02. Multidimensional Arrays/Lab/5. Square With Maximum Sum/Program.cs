namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizesOfTheMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = sizesOfTheMatrix[0];
            int cols = sizesOfTheMatrix[1];
            int[,] matrixOfNumbers = new int[rows, cols];
            for (int row = 0; row < matrixOfNumbers.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrixOfNumbers.GetLength(1); col++)
                {
                    //put the elements in the matrix
                    matrixOfNumbers[row, col] = numbers[col];
                }
            }

            int[] subMatrixLineParts = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int subRows = subMatrixLineParts[0];
            int subCols = subMatrixLineParts[1];
            long maxSum = long.MinValue;
            int maxSumRow = 0;
            int maxSumColumn = 0;
            for (int row = 0; row < matrixOfNumbers.GetLength(0) - subRows + 1; row++)
            {
                for (int col = 0; col < matrixOfNumbers.GetLength(1) - subCols + 1; col++)
                {
                    //calculate the sum from the current NXN matrix
                    long currentSum = 0;
                    for (int i = 0; i < subRows; i++)
                    {
                        for (int j = 0; j < subCols; j++)
                        {
                            currentSum += matrixOfNumbers[row + i, col + j];
                        }
                    }
                    //check if it is bigger than the maximum sum
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSumRow = row;
                        maxSumColumn = col;
                    }
                }
            }

            //print the elements from the NXN matrix with the biggest sum
            for (int row = maxSumRow; row < maxSumRow + subRows; row++)
            {
                for (int col = maxSumColumn; col < maxSumColumn + subCols; col++)
                {
                    Console.Write(matrixOfNumbers[row, col] + " ");
                }
                Console.WriteLine();
            }

            //print their sum
            Console.WriteLine(maxSum);
        }
    }
}