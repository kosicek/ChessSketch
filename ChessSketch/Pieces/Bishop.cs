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

        private static readonly Direction[] dirs = new Direction[] { Direction.DiagonalUpRight, Direction.DiagonalUpLeft, Direction.DiagonalDownRight, Direction.DiagonalDownLeft };

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

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return HavePositionsInDirs(from,board,dirs).Select(to  => new NormalMove(from,to));
        }
    }
}
