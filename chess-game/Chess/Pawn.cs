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
            Position[] testMovements = new Position[2];

            testMovements[0] = new Position(((Color.Equals(Color.White) ? Position.Line - 1 : Position.Line + 1)), Position.Column);
            
            if (Movements.Equals(0))
                testMovements[1] = new Position(((Color.Equals(Color.White) ? Position.Line - 2 : Position.Line + 2)), Position.Column);

            foreach (var currentMovement in testMovements)
            {
                try
                {
                    if(currentMovement != null && CanMove(currentMovement))
                    {
                        movements[currentMovement.Line, currentMovement.Column] = true;

                        if(ChessBoard.PieceExists(currentMovement))
                            break;
                    }
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
            return "P";
        }
    }
}
