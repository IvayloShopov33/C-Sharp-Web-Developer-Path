namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int playerRow = 0;
            int playerCol = 0;
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    //put the elements in the matrix
                    matrix[row, col] = input[col];
                    
                    //check if the current element is the player
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string directions = Console.ReadLine();
            foreach (char direction in directions)
            {
                int nextRow = 0;
                int nextCol = 0;
                
                //check the direction
                switch (direction)
                {
                    case 'U':
                        nextRow--;
                        break;
                    case 'D':
                        nextRow++;
                        break;
                    case 'L':
                        nextCol--;
                        break;
                    case 'R':
                        nextCol++;
                        break;
                    default:
                        break;
                }

                bool hasWon = false;
                bool isDead = false;
                
                //remove the player from his current position
                matrix[playerRow, playerCol] = '.';
                //check if the player is outside of the matrix and if it is true than he has won the game
                if (playerRow + nextRow < 0 || playerRow + nextRow >= matrix.GetLength(0) || playerCol + nextCol < 0 || playerCol + nextCol >= matrix.GetLength(1))
                {
                    hasWon = true;
                }
                else
                {
                    playerRow += nextRow;
                    playerCol += nextCol;
                    
                    //check if the player reached a bunny or not
                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        isDead = true;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = 'P';
                    }
                }

                List<int[]> bunniesCoordinates = new List<int[]>();
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            //add the coordinates of the bunnies to the list
                            bunniesCoordinates.Add(new int[] { row, col });
                        }
                    }
                }

                foreach (int[] coordinates in bunniesCoordinates)
                {
                    int bunnyRow = coordinates[0];
                    int bunnyCol = coordinates[1];

                    //check if it is possible for the bunnies to propagate down
                    if (bunnyRow + 1 >= 0 && bunnyRow + 1 < matrix.GetLength(0))
                    {
                        //check if the bunny reached the player
                        if (matrix[bunnyRow + 1, bunnyCol] == 'P')
                        {
                            isDead = true;
                        }
                        
                        matrix[bunnyRow + 1, bunnyCol] = 'B';
                    }

                    //check if it is possible for the bunnies to propagate up
                    if (bunnyRow - 1 >= 0 && bunnyRow - 1 < matrix.GetLength(0))
                    {
                        //check if the bunny reached the player
                        if (matrix[bunnyRow - 1, bunnyCol] == 'P')
                        {
                            isDead = true;
                        }
                        
                        matrix[bunnyRow - 1, bunnyCol] = 'B';
                    }

                    //check if it is possible for the bunnies to propagate right
                    if (bunnyCol + 1 >= 0 && bunnyCol + 1 < matrix.GetLength(1))
                    {
                        //check if the bunny reached the player
                        if (matrix[bunnyRow, bunnyCol + 1] == 'P')
                        {
                            isDead = true;
                        }
                        
                        matrix[bunnyRow, bunnyCol + 1] = 'B';
                    }

                    //check if it is possible for the bunnies to propagate left
                    if (bunnyCol - 1 >= 0 && bunnyCol - 1 < matrix.GetLength(1))
                    {
                        //check if the bunny reached the player
                        if (matrix[bunnyRow, bunnyCol - 1] == 'P')
                        {
                            isDead = true;
                        }
                        
                        matrix[bunnyRow, bunnyCol - 1] = 'B';
                    }
                }

                //check if the player has won and stop the program if it is true
                if (hasWon)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("won: " + playerRow + " " + playerCol);
                    Environment.Exit(0);
                }

                //check if the player is dead and stop the program if it is true
                if (isDead)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine("dead: " + playerRow + " " + playerCol);
                    Environment.Exit(0);
                }
            }
        }
    }
}
