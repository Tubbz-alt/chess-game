using System;

using ChessGame.Board;
using ChessGame.Board.Exceptions;

namespace ChessGame.Chess
{
    sealed class King : Piece
    {
        public King (ChessBoard chessBoard, Color color) : base(chessBoard, color)
        {
        }

        public override bool[,] PossibleMovements ()
        {
            bool[,] movements = new bool[ChessBoard.Columns, ChessBoard.Lines];
            Position[] testMovements = new Position[]
            {
                new Position(Position.Line + 1, Position.Column),
                new Position(Position.Line + 1, Position.Column + 1),
                new Position(Position.Line, Position.Column + 1),
                new Position(Position.Line - 1, Position.Column + 1),
                new Position(Position.Line - 1, Position.Column),
                new Position(Position.Line - 1, Position.Column - 1),
                new Position(Position.Line, Position.Column - 1),
                new Position(Position.Line + 1, Position.Column - 1)
            };
            
            foreach (var currentMovement in testMovements)
            {
                try
                {
                    if (CanMove(currentMovement))
                        movements[currentMovement.Line, currentMovement.Column] = true;
                }
                catch (ChessBoardException)
                {
                    continue;
                }
            }

            return movements;
        }

        public override string ToString ()
        {
            return "K";
        }
    }
}
