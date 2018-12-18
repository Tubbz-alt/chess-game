using System;

using ChessGame.Board;
using ChessGame.Chess;

namespace ChessGame
{
    class Program
    {
        static void Main (string[] args)
        {
            ChessBoard board = new ChessBoard();
            
            board.PutPiece(new King(board, Color.Yellow), new Position(1, 1));
            board.PutPiece(new Tower(board, Color.Yellow), new Position(2, 1));
            

            View.PrintChessBoard(board);

            try
            {
                board.PutPiece(new Tower(board, Color.Yellow), new Position(2, 1));           
            }
            catch (ChessGame.Board.Exceptions.ChessBoardException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
