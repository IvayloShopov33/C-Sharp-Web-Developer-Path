namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimensionsOfTheMatrix = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] minerGame = new char[dimensionsOfTheMatrix, dimensionsOfTheMatrix];
            int startingRow = 0;
            int startingColumn = 0;
            int coalCounter = 0;
            for (int row = 0; row < minerGame.GetLength(0); row++)
            {
                char[] fieldOnEachRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < minerGame.GetLength(1); col++)
                {
                    //check if the element is the start position or a coal
                    if (fieldOnEachRow[col] == 's')
                    {
                        startingRow = row;
                        startingColumn = col;
                    }
                    else if (fieldOnEachRow[col] == 'c')
                    {
                        coalCounter++;
                    }

                    //put the elements in the matrix
                    minerGame[row, col] = fieldOnEachRow[col];
                }
            }

            //starting the movement of the miner
            char currentPosition = minerGame[startingRow, startingColumn];
            for (int i = 0; i < commands.Length; i++)
            {
                //check his next direction
                string currentCommand = commands[i];
                if (currentCommand == "up")
                {
                    //check if the next move is inside of the matrix
                    if (startingRow - 1 >= 0)
                    {
                        startingRow--;
                        currentPosition = minerGame[startingRow, startingColumn];
                    }
                }
                else if (currentCommand == "down")
                {
                    //check if the next move is inside of the matrix
                    if (startingRow + 1 < minerGame.GetLength(0))
                    {
                        startingRow++;
                        currentPosition = minerGame[startingRow, startingColumn];
                    }
                }
                else if (currentCommand == "left")
                {
                    //check if the next move is inside of the matrix
                    if (startingColumn - 1 >= 0)
                    {
                        startingColumn--;
                        currentPosition = minerGame[startingRow, startingColumn];
                    }
                }
                else if (currentCommand == "right")
                {
                    //check if the next move is inside of the matrix
                    if (startingColumn + 1 < minerGame.GetLength(1))
                    {
                        startingColumn++;
                        currentPosition = minerGame[startingRow, startingColumn];
                    }
                }

                currentPosition = minerGame[startingRow, startingColumn];
                //check if the miner can collect coals or he is on the ending position
                if (currentPosition == 'c')
                {
                    //decrease the initial amount of coals
                    coalCounter--;
                    //change the character on this position
                    minerGame[startingRow, startingColumn] = '*';
                    if (coalCounter == 0)
                    {
                        //print this message with his final coordinates if he collected all coals and stop the program
                        Console.WriteLine($"You collected all coals! ({startingRow}, {startingColumn})");
                        Environment.Exit(0);
                    }
                }
                else if (currentPosition == 'e')
                {
                    //print this message with his final coordinates if he is on the final position and stop the program
                    Console.WriteLine($"Game over! ({startingRow}, {startingColumn})");
                    Environment.Exit(0);
                }
            }
            
            //print this message if he has no more moves and there are coals left
            Console.WriteLine($"{coalCounter} coals left. ({startingRow}, {startingColumn})");
        }
    }
}
