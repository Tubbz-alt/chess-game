using System;

namespace ChessGame.Board.Exceptions
{
    class ChessBoardException : Exception
    {
        public ChessBoardException (string message) : base(message)
        {

        }
    }
}
