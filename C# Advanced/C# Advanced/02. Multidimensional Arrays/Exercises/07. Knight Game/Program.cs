namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixDimension = int.Parse(Console.ReadLine());
            char[,] chessBoard = new char[matrixDimension, matrixDimension];
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                string rowOfTheChessBoard = Console.ReadLine();
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    //put the elements in the matrix
                    chessBoard[row, col] = rowOfTheChessBoard[col];
                }
            }

            int removedKnight = 0;
            while (true)
            {
                int maxAttacks = 0;
                int knightRow = 0;
                int knightCol = 0;
                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        int currentAttacks = 0;
                        //check if the current element is a knight
                        if (chessBoard[row, col] == 'K')
                        {
                            //check if the knight can attack another knight
                            if (IsInside(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsInside(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsInside(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsInside(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsInside(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsInside(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsInside(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
                            {
                                currentAttacks++;
                            }

                            if (IsInside(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
                            {
                                currentAttacks++;
                            }

                            //check if the current knight has the most attacks
                            if (currentAttacks > maxAttacks)
                            {
                                maxAttacks = currentAttacks;
                                knightRow = row;
                                knightCol = col;
                            }
                        }
                    }
                }

                //check if there are knights which can attack each other
                if (maxAttacks == 0)
                {
                    //print the count of the removed knights and stop the program
                    Console.WriteLine(removedKnight);
                    break;
                }
                else
                {
                    //remove the knight from the chess board and increase the counter of the removed knights
                    chessBoard[knightRow, knightCol] = '0';
                    removedKnight++;
                }
            }
        }

        //method which checks if the this position is valid for attack
        static bool IsInside(char[,] chessBoard, int row, int col)
        {
            if (row >= 0 && row < chessBoard.GetLength(0) &&
                col >= 0 && col < chessBoard.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
