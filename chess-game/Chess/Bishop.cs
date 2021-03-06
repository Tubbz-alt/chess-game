﻿using System;
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

            foreach(var currentMovement in positions)
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
            return "B";
        }
    }
}
