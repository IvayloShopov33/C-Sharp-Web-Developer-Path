namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDetails = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixDetails[0];
            int cols = matrixDetails[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] valuesOfRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    //put the elements in the matrix
                    matrix[row, col] = valuesOfRow[col];
                }
            }

            int sumOfEachColumn;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sumOfEachColumn = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    //adding the element from the same column to the total sum of the column
                    sumOfEachColumn += matrix[row, col];
                }
                Console.WriteLine(sumOfEachColumn);
            }
        }
    }
}