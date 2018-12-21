using System;

using ChessGame.Board;
using ChessGame.Board.Exceptions;
using ChessGame.Chess;

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

                    Console.Write("\n");

                    Console.Write("Target: ");
                    var targetPosition = View.ReadChessPosition();

                    match.ExecuteMovement(originPosition, targetPosition);
                }
                catch (ChessBoardException e)
                {
                    View.PrintException(e);
                }
            }
        }
    }
}
