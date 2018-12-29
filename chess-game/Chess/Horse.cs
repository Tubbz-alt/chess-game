using System;
using System.Collections.Generic;

using ChessGame.Board;
using ChessGame.Board.Exceptions;

namespace ChessGame.Chess
{
    sealed class Horse : Piece
    {
        public Horse (ChessBoard chessBoard, Color color)
            : base(chessBoard, color)
        {
        }

        public override bool[,] PossibleMovements ()
        {
            bool[,] movements = new bool[ChessBoard.Lines, ChessBoard.Columns];
            Position[] positions = new Position[]
            {
                new Position(Position.Line - 2, Position.Column - 1),
                new Position(Position.Line - 2, Position.Column + 1),
                new Position(Position.Line + 2, Position.Column - 1),
                new Position(Position.Line + 2, Position.Column + 1),
                new Position(Position.Line - 1, Position.Column + 2),
                new Position(Position.Line + 1, Position.Column + 2),
                new Position(Position.Line - 1, Position.Column - 2),
                new Position(Position.Line + 1, Position.Column - 2)
            };

            foreach (var currentPosition in positions)
                if (ChessBoard.IsValidPosition(currentPosition) && CanMove(currentPosition))
                    movements[currentPosition.Line, currentPosition.Column] = true;

            return movements;

        }

        public override string ToString ()
        {
            return "H";
        }
    }   
}
