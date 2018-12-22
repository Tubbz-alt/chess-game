using System;

namespace ChessGame.Chess.Exceptions
{
    class ChessMatchException : Exception
    {
        public ChessMatchException (string message) : base(message)
        {

        }
    }
}
