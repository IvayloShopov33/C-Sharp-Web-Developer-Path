namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensionsOfTheMatrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensionsOfTheMatrix[0];
            int cols = dimensionsOfTheMatrix[1];
            char[,] snakeMoves = new char[rows, cols];

            string snake = Console.ReadLine();
            bool leftToRight = true;
            int counter = 0;

            for (int row = 0; row < snakeMoves.GetLength(0); row++)
            {
                // check the next direction of the snake
                if (leftToRight)
                {
                    for (int col = 0; col < snakeMoves.GetLength(1); col++)
                    {
                        // put the elements in the matrix
                        snakeMoves[row, col] = snake[counter++];

                        if (snake.Length == counter)
                        {
                            counter = 0;
                        }
                    }

                    // change the direction
                    leftToRight = false;
                }
                else
                {
                    for (int col = snakeMoves.GetLength(1) - 1; col >= 0; col--)
                    {
                        // put the elements in the matrix
                        snakeMoves[row, col] = snake[counter++];

                        if (snake.Length == counter)
                        {
                            counter = 0;
                        }
                    }

                    // change the direction
                    leftToRight = true;
                }
            }

            // print the matrix
            for (int i = 0; i < snakeMoves.GetLength(0); i++)
            {
                for (int j = 0; j < snakeMoves.GetLength(1); j++)
                {
                    Console.Write(snakeMoves[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}