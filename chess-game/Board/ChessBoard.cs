using System;

using ChessGame.Board.Exceptions;

namespace ChessGame.Board
{
    class ChessBoard
    {
        public const int Lines = 8;
        public const int Columns = 8;

        private Piece[,] Pieces;

        public ChessBoard ()
        {
            Pieces = new Piece[Lines, Columns];
        }

        public void PutPiece (Piece piece, Position position)
        {
            ValidPosition(position);

            if (PieceExists(position))
                throw new ChessBoardException("Already exists a peace in this position!");

            Pieces[position.Line, position.Column] = piece;
            piece.AlterPosition(position);
        }

        public Piece RemovePiece (Position position)
        {
            if (PieceExists(position))
            {
                var piece = GetPiece(position);
                Pieces[position.Line, position.Column] = null;
                piece.AlterPosition(null);

                return piece;
            }
            else
            {
                return null;
            }
        }

        public bool PieceExists (Position position)
        {
            return GetPiece(position) != null;
        }

        public Piece GetPiece (Position position)
        {
            ValidPosition(position);
            return Pieces[position.Line, position.Column];    
        }

        public void ValidPosition (Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
                throw new ChessBoardException("Not valid position!");
        }
    }
}
