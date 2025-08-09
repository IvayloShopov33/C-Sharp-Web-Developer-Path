namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] triangleOfPascal = new long[rows][];

            for (int row = 0; row < rows; row++)
            {
                //initialize array in the jagged array
                triangleOfPascal[row] = new long[row + 1];

                //calculate the elements of the Pascal's triangle on each row
                triangleOfPascal[row][0] = 1;
                triangleOfPascal[row][triangleOfPascal[row].Length - 1] = 1;

                for (int col = 1; col < triangleOfPascal[row].Length - 1; col++)
                {
                    triangleOfPascal[row][col] = triangleOfPascal[row - 1][col - 1] + triangleOfPascal[row - 1][col];
                }
            }

            //print the final version of the Pascal's triangle
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(' ', triangleOfPascal[row]));
            }
        }
    }
}