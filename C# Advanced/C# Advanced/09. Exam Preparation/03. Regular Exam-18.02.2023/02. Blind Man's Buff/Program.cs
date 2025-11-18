namespace _02._Blind_Man_s_Buff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[matrixDimensions[0], matrixDimensions[1]];

            int currentRow = 0;
            int currentCol = 0;
            int movesCount = 0;
            int touchedPlayers = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (rowInput[col] == 'B')
                    {
                        currentRow = row;
                        currentCol = col;
                    }

                    matrix[row, col] = rowInput[col];
                }
            }

            string direction = Console.ReadLine();
            while (direction != "Finish")
            {
                if (direction == "up")
                {
                    if (currentRow - 1 >= 0 && matrix[currentRow - 1, currentCol] != 'O')
                    {
                        movesCount++;

                        if (matrix[currentRow - 1, currentCol] == 'P')
                        {
                            touchedPlayers++;
                            if (touchedPlayers == 3)
                            {
                                break;
                            }
                        }

                        matrix[currentRow - 1, currentCol] = 'B';
                        matrix[currentRow, currentCol] = '-';
                        currentRow--;
                    }
                }
                else if (direction == "down")
                {
                    if (currentRow + 1 < matrix.GetLength(0) && matrix[currentRow + 1, currentCol] != 'O')
                    {
                        movesCount++;
                        if (matrix[currentRow + 1, currentCol] == 'P')
                        {
                            touchedPlayers++;
                            if (touchedPlayers == 3)
                            {
                                break;
                            }
                        }

                        matrix[currentRow + 1, currentCol] = 'B';
                        matrix[currentRow, currentCol] = '-';
                        currentRow++;
                    }
                }
                else if (direction == "right")
                {

                    if (currentCol + 1 < matrix.GetLength(1) && matrix[currentRow, currentCol + 1] != 'O')
                    {
                        movesCount++;
                        if (matrix[currentRow, currentCol + 1] == 'P')
                        {
                            touchedPlayers++;
                            if (touchedPlayers == 3)
                            {
                                break;
                            }
                        }

                        matrix[currentRow, currentCol + 1] = 'B';
                        matrix[currentRow, currentCol] = '-';
                        currentCol++;
                    }
                }
                else if (direction == "left")
                {

                    if (currentCol - 1 >= 0 && matrix[currentRow, currentCol - 1] != 'O')
                    {
                        movesCount++;
                        if (matrix[currentRow, currentCol - 1] == 'P')
                        {
                            touchedPlayers++;
                            if (touchedPlayers == 3)
                            {
                                break;
                            }
                        }

                        matrix[currentRow, currentCol - 1] = 'B';
                        matrix[currentRow, currentCol] = '-';
                        currentCol--;
                    }
                }

                direction = Console.ReadLine();
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedPlayers} Moves made: {movesCount}");
        }
    }
}