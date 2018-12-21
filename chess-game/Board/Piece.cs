using System;

namespace ChessGame.Board
{
    abstract class Piece
    {
        public ChessBoard ChessBoard { get; private set; }
        public Position Position { get; protected set; }
        public Color Color { get; protected set; }
        public int Moviments { get; protected set; }
    
        public Piece (ChessBoard chessBoard, Color color)
        {
            ChessBoard = chessBoard;
            Color = color;

            Position = null;
            Moviments = 0;
        }  
      
        public void IncrementMoviments ()
        {
            Moviments++;
        }

        public void AlterPosition (Position newPosition)
        {
            Position = newPosition;
        }
    }
}
