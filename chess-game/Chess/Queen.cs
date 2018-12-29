using System.Collections.Generic;

using ChessGame.Board;
using ChessGame.Board.Exceptions;

namespace ChessGame.Chess
{
    sealed class Queen : Piece
    {
        public Queen (ChessBoard chessBoard, Color color) 
            : base(chessBoard, color)
        {
        }

        public override bool[,] PossibleMovements ()
        {
            List<Position> positions = new List<Position>();
            bool[,] movements = new bool[ChessBoard.Columns, ChessBoard.Lines];
            var loopCount = 1;

            // Left movement
            for (int c = Position.Column - 1; c >= 0; c--)
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

            for (var c = Position.Column; c < ChessBoard.Columns; c++)
            {
                var position = new Position(Position.Line - loopCount, Position.Column + loopCount);
                TestMovement(position, positions);

                if (ChessBoard.IsValidPosition(position) && ChessBoard.PieceExists(position))
                    break;

                loopCount++;
            }

            loopCount = 1;

            for (var c = Position.Column; c >= 0; c--)
            {
                var position = new Position(Position.Line - loopCount, Position.Column - loopCount);
                TestMovement(position, positions);

                if (ChessBoard.IsValidPosition(position) && ChessBoard.PieceExists(position))
                    break;

                loopCount++;
            }

            loopCount = 1;

            for (var c = Position.Column; c >= 0; c--)
            {
                var position = new Position(Position.Line + loopCount, Position.Column - loopCount);
                TestMovement(position, positions);

                if (ChessBoard.IsValidPosition(position) && ChessBoard.PieceExists(position))
                    break;
                
                loopCount++;
            }

            loopCount = 1;

            for (var c = Position.Column; c < ChessBoard.Columns; c++)
            {
                var position = new Position(Position.Line + loopCount, Position.Column + loopCount);
                TestMovement(position, positions);

                if (ChessBoard.IsValidPosition(position) && ChessBoard.PieceExists(position))
                    break;

                loopCount++;
            }

            foreach (var currentMovement in positions)
                movements[currentMovement.Line, currentMovement.Column] = true;

            return movements;
        }

        private void TestMovement (Position position, List<Position> positions)
        {
            if (ChessBoard.IsValidPosition(position) && CanMove(position))
                positions.Add(position);
        }

        public override string ToString ()
        {
            return "Q";
        }
    }
}
