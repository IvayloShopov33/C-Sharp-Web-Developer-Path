namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensionsOfTheMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = dimensionsOfTheMatrix[0];
            int cols = dimensionsOfTheMatrix[1];
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    //put the elements in the matrix
                    matrix[row, col] = elements[col];
                }
            }

            string[] commands;
            while (true)
            {
                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                //check the type of the command and also if it is valid or not
                if (commands[0] == "END")
                {
                    break;
                }
                else if (commands[0] == "swap" && commands.Length==5)
                {
                    //swapping the elements with these coordinates
                    int row1 = int.Parse(commands[1]);
                    int col1 = int.Parse(commands[2]);
                    int row2 = int.Parse(commands[3]);
                    int col2 = int.Parse(commands[4]);
                    
                    //check if the coordinates are valid or not
                    if (row1 >= 0 && row1 < matrix.GetLength(0) && col1 >= 0 && col1 < matrix.GetLength(1) &&
                        row2 >= 0 && row2 < matrix.GetLength(0) && col2 >= 0 && col2 < matrix.GetLength(1))
                    {
                        string firstElement = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = firstElement;
                        
                        //print the state of the matrix
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
