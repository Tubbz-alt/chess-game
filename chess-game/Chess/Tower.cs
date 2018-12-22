using System;

using ChessGame.Board;
using ChessGame.Board.Exceptions;

namespace ChessGame.Chess
{
    sealed class Tower : Piece
    {
        public Tower (ChessBoard chessBoard, Color color)
            : base(chessBoard, color)
        {
        }

        public override bool[,] PossibleMovements ()
        {
            bool[,] movements = new bool[ChessBoard.Columns, ChessBoard.Lines];

            // Left movement
            for (int c = Position.Column - 1; c >= 0;  c--)
            {
                var position = new Position(Position.Line, c);

                if (CanMove(position))
                    movements[position.Line, c] = true;

                if (ChessBoard.PieceExists(position))
                    break;
            }
            // Right movement
            for (int c = Position.Column + 1; c < 8; c++)
            {
                var position = new Position(Position.Line, c); 

                if (CanMove(position))
                    movements[Position.Line, c] = true;

                if (ChessBoard.PieceExists(position))
                    break;
            }
            // Up movement
            for (int l = Position.Line - 1; l >= 0; l--)
            {
                var position = new Position(l, Position.Column);

                if (CanMove(position))
                    movements[l, Position.Column] = true;

                if (ChessBoard.PieceExists(position))
                    break;
            }
            // Down movement
            for (int l = Position.Line + 1; l < 8; l++)
            {
                var position = new Position(l, Position.Column);

                if (CanMove(position))
                    movements[l, Position.Column] = true;

                if (ChessBoard.PieceExists(position))
                    break;
            }

            return movements;
        }

        public override string ToString ()
        {
            return "T";
        }
    }
}
