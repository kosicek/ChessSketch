using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class Bishop : ChessPiece
    {
        public override Piecetype Type => Piecetype.Bishop;

        public override Team Color { get; }

        public Bishop(Team color)
        {
            Color = color;
        }

        public override ChessPiece Copy()
        {
            Bishop copy = new Bishop(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
