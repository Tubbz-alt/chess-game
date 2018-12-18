using System;

using ChessGame.Board;

namespace ChessGame.Chess
{
    sealed class King : Piece
    {
        public King (ChessBoard chessBoard, Color color) : base(chessBoard, color)
        {
        }

        public override string ToString ()
        {
            return "K";
        }
    }
}
