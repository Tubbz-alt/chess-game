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

            for (int l = 0; l < ChessBoard.Lines; l++)
            {
                PrintChessBoardVerticalLabel(l);

                for (int c = 0; c < ChessBoard.Columns; c++)
                    PrintChessBoardPiece(chessBoard.GetPiece(new Position(l, c)), false);

                Console.WriteLine();
            }

            PrintChessBoardHorizontalLabel();

            Console.Write("\n\n");
        }

        public static void PrintChessBoard (ChessBoard chessBoard, ChessPosition origin)
        {
            Console.Clear();

            for (int l = 0; l < ChessBoard.Lines; l++)
            {
                PrintChessBoardVerticalLabel(l);

                for (int c = 0; c < ChessBoard.Columns; c++)
                {
                    var currentPosition = new Position(l, c);
                    bool[,] possibleMovements = chessBoard.GetPiece(origin.ToPosition()).PossibleMovements();

                    if (possibleMovements[l, c])
                        PrintChessBoardPiece(chessBoard.GetPiece(currentPosition), true);
                    else
                        PrintChessBoardPiece(chessBoard.GetPiece(currentPosition));
                }
                Console.WriteLine();
            }

            PrintChessBoardHorizontalLabel();

            Console.Write("\n\n");
        }

        public static void PrintMatchStatus (ChessMatch chessMatch)
        {
            Console.WriteLine("Turn: {0}", chessMatch.Turn);
            Console.WriteLine("Current player: {0} piece's", chessMatch.CurrentPlayer);
            PrintOutOfGamePiecesByColor(chessMatch, Color.White);
            PrintOutOfGamePiecesByColor(chessMatch, Color.DarkGray);

            if (chessMatch.Check)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("CHECK!!!");
                Console.ForegroundColor = _defaultConsoleForegroundColor;
            }

            Console.Write("\n\n");
        }

        public static void PrintEndOfMatch (ChessMatch chessMatch)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CHECKMATE!!!\n");
            Console.ForegroundColor = _defaultConsoleForegroundColor;

            Console.WriteLine("Winner: {0} piece's", chessMatch.CurrentPlayer);
            Console.WriteLine("Turn: {0}", chessMatch.Turn);
            Console.WriteLine("Started at: {0}", chessMatch.StartedAt);
            Console.WriteLine("Finished at: {0}\n", chessMatch.FinishedAt);

            PrintChessBoardOnEndOfMatch(chessMatch.ChessBoard);

            Console.ReadLine();
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
            
            Console.WriteLine("[Error]: {0}", e.Message);
            Console.ReadLine();

            Console.ForegroundColor = _defaultConsoleForegroundColor;            
        }

        private static void PrintChessBoardPiece (Piece piece)
        {
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
            Console.Write(ChessBoard.Lines - line + " ");
        }

        private static void PrintChessBoardHorizontalLabel ()
        {
            string label = "  ";

            for (int c = 0; c < ChessBoard.Columns; c++)
                label += (char)('a' + c) + " ";

            Console.Write(label.ToUpper());
        }
    
        private static void PrintOutOfGamePiecesByColor (ChessMatch chessMatch, Color color)
        {
            Console.Write("Out pieces: ");
            Console.ForegroundColor = (ConsoleColor)color;
            string value = "[";

            foreach (var piece in chessMatch.GetOutOfGamePieces(color))
                value += (piece + " ");

            value += "]";

            Console.WriteLine(value);
            Console.ForegroundColor = _defaultConsoleForegroundColor;
        }

        private static void PrintChessBoardOnEndOfMatch (ChessBoard chessBoard)
        {
            for (int l = 0; l < ChessBoard.Lines; l++)
            {
                PrintChessBoardVerticalLabel(l);

                for (int c = 0; c < ChessBoard.Columns; c++)
                    PrintChessBoardPiece(chessBoard.GetPiece(new Position(l, c)), false);

                Console.WriteLine();
            }

            PrintChessBoardHorizontalLabel();

            Console.Write("\n\n");
        }
    }
}
