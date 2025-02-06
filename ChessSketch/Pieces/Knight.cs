using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class Knight : ChessPiece
    {
        public override Piecetype Type => Piecetype.Pawn;

        public override Team Color { get; }

        public Knight(Team color)
        {
            Color = color;
        }

        public override ChessPiece Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
