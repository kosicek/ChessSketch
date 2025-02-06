﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class Rook : ChessPiece
    {
        public override Piecetype Type => Piecetype.Pawn;

        public override Team Color { get; }

        public Rook(Team color)
        {
            Color = color;
        }

        public override ChessPiece Copy()
        {
            Rook copy = new Rook(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
