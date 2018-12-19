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

            board.PutPiece(new King(board, Color.Yellow), new Position(0, 0));
            board.PutPiece(new Tower(board, Color.Yellow), new Position(1, 1));

            View.PrintChessBoard(board);

            board.RemovePiece(new Position(1, 1));
            
            View.PrintChessBoard(board);

            Console.ReadLine();
        }
    }
}
