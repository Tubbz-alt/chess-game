using System;
using System.Collections.Generic;

using ChessGame.Board;
using ChessGame.Board.Exceptions;

namespace ChessGame.Chess
{
    sealed class Pawn : Piece   
    {
        public Pawn (ChessBoard chessBoard, Color color)
            : base(chessBoard, color)
        {
        }

        public override bool[,] PossibleMovements ()
        {
            bool[,] movements = new bool[ChessBoard.Lines, ChessBoard.Columns];
            Position[] positions = new Position[4];

            if(Color.Equals(Color.White))
            {
                positions[0] = (new Position(Position.Line - 1, Position.Column));
                positions[1] = Movements.Equals(0) ? (new Position(Position.Line - 2, Position.Column)) : null;
                positions[2] = (new Position(Position.Line - 1, Position.Column + 1));
                positions[3] = (new Position(Position.Line - 1, Position.Column - 1));
            }
            else
            {
                positions[0] = (new Position(Position.Line + 1, Position.Column));
                positions[1] = Movements.Equals(0) ? (new Position(Position.Line + 2, Position.Column)) : null;
                positions[2] = (new Position(Position.Line + 1, Position.Column + 1));
                positions[3] = (new Position(Position.Line + 1, Position.Column - 1));
            }

            for (var c = 0; c < positions.Length; c++ )
            {
                var currentPosition = positions[c];

                if (currentPosition != null && ChessBoard.IsValidPosition(currentPosition))
                {
                    if (c < 2)
                    {
                        if (CanMove(currentPosition))
                            movements[currentPosition.Line, currentPosition.Column] = true;
                    }
                    else
                    {
                        if (ChessBoard.HasEnemy(currentPosition, ChessMatch.Adversary(Color)))
                            movements[currentPosition.Line, currentPosition.Column] = true;
                    }
                }   
            }

            return movements;
        }

        protected override bool CanMove (Position position)
        {
            return !ChessBoard.PieceExists(position);
        }

        public override string ToString ()
        {
            return "P";
        }
    }
}
