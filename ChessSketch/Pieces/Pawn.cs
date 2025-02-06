using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class Pawn : ChessPiece
    {
        public override Piecetype Type => Piecetype.Pawn;
        
        public override Team Color { get; }

        public Pawn(Team color)
        {
            Color = color;
        }

        public override ChessPiece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
