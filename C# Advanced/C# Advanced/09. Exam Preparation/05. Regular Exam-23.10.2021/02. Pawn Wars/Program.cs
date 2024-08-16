using System;

namespace _02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] chessBoard = new char[8, 8];
            int whiteCurrentRow = 0, whiteCurrentCol = 0, blackCurrentRow = 0, blackCurrentCol = 0;

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    if (inputRow[col] == 'w')
                    {
                        whiteCurrentRow = row;
                        whiteCurrentCol = col;
                    }
                    else if (inputRow[col] == 'b')
                    {
                        blackCurrentRow = row;
                        blackCurrentCol = col;
                    }

                    chessBoard[row, col] = inputRow[col];
                }
            }

            char[] rowsSymbols = new char[8] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            bool gameOver = false;
            int pawnTurn = 0;

            while (!gameOver)
            {
                if (pawnTurn % 2 == 0)
                {
                    bool isInsideFirstOption = whiteCurrentCol - 1 >= 0;
                    bool isInsideSecondOption = whiteCurrentCol + 1 < chessBoard.GetLength(1);
                    if (whiteCurrentRow == 0)
                    {
                        string coordinates = rowsSymbols[whiteCurrentCol] + 8.ToString();
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinates}.");
                        gameOver = true;
                    }
                    else if (isInsideFirstOption && chessBoard[whiteCurrentRow - 1, whiteCurrentCol - 1] == 'b')
                    {
                        string coordinates = rowsSymbols[whiteCurrentCol - 1] + (8 - blackCurrentRow).ToString();
                        Console.WriteLine($"Game over! White capture on {coordinates}.");
                        gameOver = true;
                    }
                    else if (isInsideSecondOption && chessBoard[whiteCurrentRow - 1, whiteCurrentCol + 1] == 'b')
                    {
                        string coordinates = rowsSymbols[whiteCurrentCol + 1] + (8 - blackCurrentRow).ToString();
                        Console.WriteLine($"Game over! White capture on {coordinates}.");
                        gameOver = true;
                    }
                    else
                    {
                        chessBoard[whiteCurrentRow - 1, whiteCurrentCol] = 'w';
                        chessBoard[whiteCurrentRow, whiteCurrentCol] = '-';
                        whiteCurrentRow--;
                    }

                    pawnTurn++;
                }
                else
                {
                    bool isInsideFirstOption = blackCurrentCol - 1 >= 0;
                    bool isInsideSecondOption = blackCurrentCol + 1 < chessBoard.GetLength(1);
                    if (blackCurrentRow == chessBoard.GetLength(0) - 1)
                    {
                        string coordinates = rowsSymbols[blackCurrentCol] + 1.ToString();
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinates}.");
                        gameOver = true;
                    }
                    else if (isInsideFirstOption && chessBoard[blackCurrentRow + 1, blackCurrentCol - 1] == 'w')
                    {
                        string coordinates = rowsSymbols[blackCurrentCol - 1] + (8 - whiteCurrentRow).ToString();
                        Console.WriteLine($"Game over! Black capture on {coordinates}.");
                        gameOver = true;
                    }
                    else if (isInsideSecondOption && chessBoard[blackCurrentRow + 1, blackCurrentCol + 1] == 'w')
                    {
                        string coordinates = rowsSymbols[blackCurrentCol + 1] + (8 - whiteCurrentRow).ToString();
                        Console.WriteLine($"Game over! Black capture on {coordinates}.");
                        gameOver = true;
                    }
                    else
                    {
                        chessBoard[blackCurrentRow + 1, blackCurrentCol] = 'b';
                        chessBoard[blackCurrentRow, blackCurrentCol] = '-';
                        blackCurrentRow++;
                    }

                    pawnTurn++;
                }
            }
        }
    }
}