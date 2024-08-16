namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[squareMatrixSize, squareMatrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    //put the elements in the matrix
                    matrix[row, col] = numbers[col];
                }
            }

            //calculate the sums of both diagonals
            int sumOfThePrimaryDiagonal = 0;
            int sumOfTheSecondaryDiagonal = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sumOfThePrimaryDiagonal += matrix[i, i];
                sumOfTheSecondaryDiagonal += matrix[i, matrix.GetLength(1) - 1 - i];
            }

            //calculate the difference between the sums of diagonals and print it
            int diagonalDifferenceAbsValue = Math.Abs(sumOfThePrimaryDiagonal - sumOfTheSecondaryDiagonal);
            Console.WriteLine(diagonalDifferenceAbsValue);
        }
    }
}