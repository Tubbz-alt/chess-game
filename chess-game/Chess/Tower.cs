using System;

using ChessGame.Board;

namespace ChessGame.Chess
{
    sealed class Tower : Piece
    {
        public Tower (ChessBoard chessBoard, Color color)
            : base(chessBoard, color)
        {
        }

        public override string ToString ()
        {
            return "T";
        }
    }
}
