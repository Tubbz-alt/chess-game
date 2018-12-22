using System;

using ChessGame.Board;
using ChessGame.Board.Exceptions;
using ChessGame.Chess;

namespace ChessGame
{
    static class View
    {
        private static readonly ConsoleColor _defaultConsoleForegroundColor = ConsoleColor.Gray;
        private static readonly ConsoleColor _defaultConsoleBackgroundColor = ConsoleColor.Black;

        public static void PrintChessBoard (ChessBoard chessBoard)
        {
            Console.Clear();

            for (int l = 0; l < chessBoard.Lines; l++)
            {
                PrintChessBoardVerticalLabel(l);

                for (int c = 0; c < chessBoard.Columns; c++)
                    PrintChessBoardPiece(chessBoard.GetPiece(new Position(l, c)), false);

                Console.WriteLine();
            }

            PrintChessBoardHorizontalLabel();

            Console.Write("\n\n");
        }

        public static void PrintChessBoard (ChessBoard chessBoard, ChessPosition origin)
        {
            Console.Clear();

            for (int l = 0; l < chessBoard.Lines; l++)
            {
                PrintChessBoardVerticalLabel(l);

                for (int c = 0; c < chessBoard.Columns; c++)
                {
                    bool[,] possibleMovements = chessBoard.GetPiece(origin.ToPosition()).PossibleMovements();

                    if (possibleMovements[l, c])
                        PrintChessBoardPiece(chessBoard.GetPiece(new Position(l, c)), true);
                    else
                        PrintChessBoardPiece(chessBoard.GetPiece(new Position(l, c)), false);
                }
                Console.WriteLine();
            }

            PrintChessBoardHorizontalLabel();

            Console.Write("\n\n");
        }

        public static ChessPosition ReadChessPosition ()
        {
            var s = Console.ReadLine();

            if(s.Length.Equals(2))
            {
                if (char.IsLetter(s[0]) && char.IsNumber(s[1]))
                    return new ChessPosition(char.ToLower(s[0]), int.Parse(s[1].ToString()));
                else
                    throw new ChessBoardException("Invalid position!");
            }
            else
            {
                throw new ChessBoardException("Invalid position!");
            }
        }

        public static void PrintException (Exception e)
        {
            Console.Clear();

            Console.ForegroundColor = (ConsoleColor)Color.Red;
            
            Console.Write("[Error]: {0}", e.Message);
            Console.ReadLine();

            Console.ForegroundColor = _defaultConsoleForegroundColor;            
        }

        private static void PrintChessBoardPiece (Piece piece, bool possibleMovement)
        {
            if (possibleMovement)
                Console.BackgroundColor = (ConsoleColor)Color.DarkYellow;

            if (piece != null)
            {
                Console.ForegroundColor = (ConsoleColor)piece.Color;
                Console.Write(piece + " ");
                Console.ForegroundColor = _defaultConsoleForegroundColor;
            }
            else
            {
                Console.Write("- ");
            }

            Console.BackgroundColor = _defaultConsoleBackgroundColor;
        }

        private static void PrintChessBoardVerticalLabel (int line)
        {
            Console.Write(8 - line + " ");
        }

        private static void PrintChessBoardHorizontalLabel ()
        {
            string label = "  ";
            var firstChar = (int)'a';

            for (int c = 0; c < 8; c++)
                label += (char)(firstChar + c) + " ";

            Console.Write(label.ToUpper());
        }
    }
}
