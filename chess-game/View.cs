using System;

using ChessGame.Board;

namespace ChessGame
{
    static class View
    {
        public static void PrintChessBoard (ChessBoard chessBoard)
        {
            Console.Clear();

            var defaultConsoleColor = Console.ForegroundColor;

            for (int l = 0; l < chessBoard.Lines; l++)
            {
                for (int c = 0; c < chessBoard.Columns; c++)
                {
                    if (chessBoard.GetPiece(new Position(l, c)) != null)
                    {
                        var piece = chessBoard.GetPiece(new Position(l, c));

                        Console.ForegroundColor = (ConsoleColor)piece.Color;
                        Console.Write(piece + " ");
                        Console.ForegroundColor = defaultConsoleColor;
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                        
                }

                Console.WriteLine();
            }
        }
    }
}
