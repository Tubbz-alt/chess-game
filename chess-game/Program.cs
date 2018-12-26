using System;

using ChessGame.Board;
using ChessGame.Board.Exceptions;
using ChessGame.Chess;
using ChessGame.Chess.Exceptions;

namespace ChessGame
{
    class Program
    {
        static void Main (string[] args)
        {
            ChessMatch match = new ChessMatch();

            while (!match.Finished)
            {
                View.PrintChessBoard(match.ChessBoard);
                View.PrintMatchStatus(match);

                try
                {
                    Console.Write("Origin: ");
                    var originPosition = View.ReadChessPosition();

                    match.CheckOriginPosition(originPosition);
                    
                    // Print the chess board with the piece's possible movements
                    View.PrintChessBoard(match.ChessBoard, originPosition);
                    View.PrintMatchStatus(match);

                    Console.WriteLine("Origin: {0}{1}", char.ToUpper(originPosition.Column), originPosition.Line);

                    Console.Write("Target: ");
                    var targetPosition = View.ReadChessPosition();

                    match.CheckTargetPosition(targetPosition);

                    match.ExecuteMovement(originPosition, targetPosition);
                }
                catch (ChessBoardException e)
                {
                    View.PrintException(e);
                }
                catch (ChessMatchException e)
                {
                    View.PrintException(e);
                }
            }

            View.PrintEndOfMatch(match);
        }
    }
}
