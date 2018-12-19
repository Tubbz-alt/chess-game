using System;

using ChessGame.Board;

namespace ChessGame
{
    static class View
    {
        private static readonly ConsoleColor _defaultConsoleColor = ConsoleColor.Gray;

        public static void PrintChessBoard (ChessBoard chessBoard)
        {
            Console.Clear();

            var defaultConsoleColor = Console.ForegroundColor;

            for (int l = 0; l < chessBoard.Lines; l++)
            {
                PrintChessBoardVerticalLabel(l);

                for (int c = 0; c < chessBoard.Columns; c++)
                    PrintChessBoardPiece(chessBoard.GetPiece(new Position(l, c)));

                Console.WriteLine();
            }

            PrintChessBoardHorizontalLabel();
        }

        private static void PrintChessBoardPiece (Piece piece)
        {
            if (piece != null)
            {
                Console.ForegroundColor = (ConsoleColor)piece.Color;
                Console.Write(piece + " ");
                Console.ForegroundColor = _defaultConsoleColor;
            }
            else
            {
                Console.Write("- ");
            }
        }

        private static void PrintChessBoardVerticalLabel (int line)
        {
            Console.ForegroundColor = (ConsoleColor)Color.DarkGray;
            Console.Write(8 - line + " ");
            Console.ForegroundColor = _defaultConsoleColor;
        }

        private static void PrintChessBoardHorizontalLabel ()
        {
            Console.ForegroundColor = (ConsoleColor)Color.DarkGray;
            string label = "  ";
            var firstChar = (int)'a';

            for (int c = 0; c < 8; c++)
                label += (char)(firstChar + c) + " ";

            Console.Write(label.ToUpper());
            Console.ForegroundColor = _defaultConsoleColor;
        }

    }
}
