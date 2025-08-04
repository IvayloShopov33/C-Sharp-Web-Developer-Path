namespace _1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            int rows = matrixSize[0];
            int columns = matrixSize[1];

            for (int row = 0; row < rows; row++)
            {
                int[] rowsValues = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int column = 0; column < columns; column++)
                {
                    //put the elements in the matrix
                    matrix[row, column] = rowsValues[column];
                }
            }

            int totalSumOfAllElements = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    //adding the elements from the matrix to the total sum
                    totalSumOfAllElements += matrix[row, column];
                }
            }

            //print the rows of the matrix
            Console.WriteLine(rows);

            //print the columns of the matrix
            Console.WriteLine(columns);

            //print the sum of all matrix elements
            Console.WriteLine(totalSumOfAllElements);
        }
    }
}