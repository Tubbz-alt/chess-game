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

                try
                {
                    Console.Write("Origin: ");
                    var originPosition = View.ReadChessPosition();

                    if(match.ChessBoard.PieceExists(originPosition.ToPosition()))
                    {
                        if (match.ChessBoard.GetPiece(originPosition.ToPosition()).Color.Equals(match.CurrentPlayer))
                            // Print chess board with the piece's possible movements
                            View.PrintChessBoard(match.ChessBoard, originPosition);
                        else
                            throw new ChessMatchException("You can only movement your pieces");
                    }

                    Console.Write("Target: ");
                    var targetPosition = View.ReadChessPosition();

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
        }
    }
}
