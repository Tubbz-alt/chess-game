using System;

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
            bool[,] movements = new bool[ChessBoard.Lines, ChessBoard.Columns];
            var loopCount = 1;

            for (int c = Position.Column + 1; c < 8; c++)
            {
                var position = new Position(Position.Line - loopCount, c);

                try
                {
                    if (CanMove(position))
                        movements[position.Line, c] = true;

                    if (ChessBoard.PieceExists(position) || c + 1 >= 8)
                    {
                        loopCount = 1;
                        break;
                    }
                }
                catch (ChessBoardException)
                {
                    continue;
                }

                loopCount++;
            }

            for (int c = Position.Column - 1; c >= 0; c--)
            {
                var position = new Position(Position.Line - loopCount, c);

                try
                {
                    if (CanMove(position))
                        movements[position.Line, c] = true;

                    if (ChessBoard.PieceExists(position) || c - 1 < 0)
                    {
                        loopCount = 1;
                        break;
                    }
                }
                catch (ChessBoardException)
                {
                    continue;
                }
                
                loopCount++;
            }

            for (int c = Position.Column + 1; c < 8; c++)
            {
                var position = new Position(Position.Line + loopCount, c);

                try
                {
                    if (CanMove(position))
                        movements[position.Line, c] = true;

                    if (ChessBoard.PieceExists(position) || c + 1 >= 8)
                    {
                        loopCount = 1;
                        break;
                    }
                }
                catch (ChessBoardException)
                {
                    continue;
                }

                loopCount++;
            }

            for (int c = Position.Column - 1; c >= 0; c--)
            {
                var position = new Position(Position.Line + loopCount, c);

                try
                {
                    if (CanMove(position))
                        movements[position.Line, c] = true;

                    if (ChessBoard.PieceExists(position) || c - 1 < 0)
                    {
                        loopCount = 1;
                        break;
                    }
                }
                catch (ChessBoardException)
                {
                    continue;
                }

                loopCount++;
            }

            return movements;
        }

        public override string ToString ()
        {
            return "B";
        }
    }
}
