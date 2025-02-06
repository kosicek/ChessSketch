using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class King : ChessPiece
    {
        public override Piecetype Type => Piecetype.Pawn;

        public override Team Color { get; }

        public King(Team color)
        {
            Color = color;
        }

        public override ChessPiece Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
