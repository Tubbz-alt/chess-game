using System;

namespace ChessGame.Board
{
    abstract class Piece
    {
        public ChessBoard ChessBoard { get; private set; }
        public Position Position { get; protected set; }
        public Color Color { get; protected set; }
        public int Movements { get; private set; }

        public Piece (ChessBoard chessBoard, Color color)
        {
            ChessBoard = chessBoard;
            Color = color;

            Position = null;
            Movements = 0;
        }  
      
        public void IncrementMovement ()
        {
            Movements++;
        }

        public void DecrementMovement ()
        {
            Movements--;
        }

        public void AlterPosition (Position newPosition)
        {
            Position = newPosition;
        }

        public bool IsPossibleMovement (Position position)
        {
            return PossibleMovements()[position.Line, position.Column];
        }

        protected bool CanMove (Position position)
        {
            return (!ChessBoard.PieceExists(position) ||  ChessBoard.GetPiece(position).Color != Color);
        }

        public abstract bool[,] PossibleMovements ();
    }
}
