using System;

using ChessGame.Board;

namespace ChessGame.Chess
{
    class ChessPosition
    {
        public char Column { get; private set; }
        public int Line { get; private set; }
        
        public ChessPosition (char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position ToPosition ()
        {
            return new Position(8 - Line, Column - 'a');
        }

        public override string ToString ()
        {
            return string.Concat(Column, Line);
        }
    }
}
