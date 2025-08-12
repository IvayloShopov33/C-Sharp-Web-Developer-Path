namespace _2._2X2_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] characters = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    // put the elements in the matrix
                    matrix[row, col] = characters[col];
                }
            }

            // finds squares of equal characters in the matrix
            int squaresOfEqualChars = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    string character = matrix[row, col];

                    // check if the elements are the same
                    if (matrix[row, col + 1] == character && matrix[row + 1, col] == character &&
                        matrix[row + 1, col + 1] == character)
                    {
                        squaresOfEqualChars++;
                    }
                }
            }
            
            Console.WriteLine(squaresOfEqualChars);
        }
    }
}