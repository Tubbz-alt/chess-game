using System;
using System.Collections.Generic;

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
            List<Position> positions = new List<Position>();
            bool[,] movements = new bool[ChessBoard.Columns, ChessBoard.Lines];

            // Left movement
            for (int c = Position.Column - 1; c >= 0;  c--)
            {
                var position = new Position(Position.Line, c);
                TestMovement(position, positions);

                if (ChessBoard.PieceExists(position))
                    break;
            }
            // Right movement
            for (int c = Position.Column + 1; c < 8; c++)
            {
                var position = new Position(Position.Line, c);
                TestMovement(position, positions);

                if (ChessBoard.PieceExists(position))
                    break;
            }
            // Up movement
            for (int l = Position.Line - 1; l >= 0; l--)
            {
                var position = new Position(l, Position.Column);
                TestMovement(position, positions);

                if (ChessBoard.PieceExists(position))
                    break;
            }
            // Down movement
            for (int l = Position.Line + 1; l < 8; l++)
            {
                var position = new Position(l, Position.Column);
                TestMovement(position, positions);

                if (ChessBoard.PieceExists(position))
                    break;
            }

            foreach (var currentPosition in positions)
                movements[currentPosition.Line, currentPosition.Column] = true;

            return movements;
        }

        private void TestMovement (Position position, List<Position> positions)
        {
            if (CanMove(position))
                positions.Add(position);
        }

        public override string ToString ()
        {
            return "T";
        }
    }
}
