namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());
            int[,] squareMatrix = new int[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            for (int row = 0; row < squareMatrix.GetLength(0); row++)
            {
                int[] rows = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < squareMatrix.GetLength(1); col++)
                {
                    //put the elements in the matrix
                    squareMatrix[row, col] = rows[col];
                }
            }

            int sumOfThePrimaryDiagonal = 0;

            for (int rowAndColumn = 0; rowAndColumn < squareMatrix.GetLength(0); rowAndColumn++)
            {
                //adding the element from the primary diagonal to his total sum
                sumOfThePrimaryDiagonal += squareMatrix[rowAndColumn, rowAndColumn];
            }

            //print the sum of the primary diagonal
            Console.WriteLine(sumOfThePrimaryDiagonal);
        }
    }
}