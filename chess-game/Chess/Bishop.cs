using System;
using System.Collections.Generic;

using ChessGame.Board;
using ChessGame.Board.Exceptions;

namespace ChessGame.Chess
{
    sealed class Bishop : Piece
    {
        public Bishop (ChessBoard chessBoard, Color color) 
            : base(chessBoard, color)
        {
        }

        public override bool[,] PossibleMovements ()
        {
            List<Position> positions = new List<Position>();
            bool[,] movements = new bool[ChessBoard.Lines, ChessBoard.Columns];
            var loopCount = 1;

            for (var c = Position.Column; c < ChessBoard.Columns; c++ )
            {
                var currentPosition = new Position(Position.Line - loopCount, Position.Column + loopCount);

                if (ChessBoard.IsValidPosition(currentPosition))
                {
                    positions.Add(currentPosition);

                    if (ChessBoard.PieceExists(currentPosition))
                        break;
                }
                loopCount++;
            }

            loopCount = 1;

            for (var c = Position.Column; c >= 0; c--)
            {
                var currentPosition = new Position(Position.Line - loopCount, Position.Column - loopCount);

                if (ChessBoard.IsValidPosition(currentPosition)) 
                {
                    positions.Add(currentPosition);

                    if (ChessBoard.PieceExists(currentPosition))
                        break;
                }
                loopCount++;
            }

            loopCount = 1;

            for (var c = Position.Column; c >= 0; c--)
            {
                var currentPosition = new Position(Position.Line + loopCount, Position.Column - loopCount);
                
                if(ChessBoard.IsValidPosition(currentPosition))
                {
                    positions.Add(currentPosition);

                    if (ChessBoard.PieceExists(currentPosition))
                        break;
                }
                loopCount++;
            }

            loopCount = 1;

            for (var c = Position.Column; c < ChessBoard.Columns; c++)
            {
                var currentPosition = new Position(Position.Line + loopCount, Position.Column + loopCount);
                
                if(ChessBoard.IsValidPosition(currentPosition))
                {
                    positions.Add(currentPosition);

                    if (ChessBoard.PieceExists(currentPosition))
                        break;
                }
                loopCount++;
            }

            foreach(var currentMovement in positions)
                if (CanMove(currentMovement))
                    movements[currentMovement.Line, currentMovement.Column] = true;

            return movements;
        }

        public override string ToString ()
        {
            return "B";
        }
    }
}
