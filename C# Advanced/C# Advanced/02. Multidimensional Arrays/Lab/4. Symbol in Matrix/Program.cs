namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareMatrixSize = int.Parse(Console.ReadLine());
            char[,] matrixOfSymbols = new char[squareMatrixSize, squareMatrixSize];

            for (int row = 0; row < matrixOfSymbols.GetLength(0); row++)
            {
                string symbols = Console.ReadLine();
                for (int col = 0; col < matrixOfSymbols.GetLength(1); col++)
                {
                    //put the elements in the matrix
                    matrixOfSymbols[row, col] = symbols[col];
                }
            }

            char inputSymbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < matrixOfSymbols.GetLength(0); row++)
            {
                for (int col = 0; col < matrixOfSymbols.GetLength(1); col++)
                {
                    //check if the symbol is present in the matrix
                    if (matrixOfSymbols[row, col] == inputSymbol)
                    {
                        //print its coordinates
                        Console.WriteLine($"({row}, {col})");

                        //stop the program
                        Environment.Exit(0);
                    }
                }
            }

            //print this message if the symbol is not present in the matrix
            Console.WriteLine($"{inputSymbol} does not occur in the matrix");
        }
    }
}