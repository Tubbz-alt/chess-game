﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Board
{
    class Position
    {
        public int Line { get; private set; }
        public int Column { get; private set; }
    
        public Position (int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString ()
        {
            return Line + ", " + Column;
        }
    }
}
