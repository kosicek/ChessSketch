using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class Queen : ChessPiece
    {
        public override Piecetype Type => Piecetype.Queen;

        public override Team Color { get; }

        private static readonly Direction[] dirs = new Direction[] 
        { Direction.Up, Direction.Down, Direction.Left, Direction.Right, Direction.DiagonalUpRight, Direction.DiagonalUpLeft, Direction.DiagonalDownRight, Direction.DiagonalDownLeft };

        public Queen(Team color)
        {
            Color = color;
        }

        public override ChessPiece Copy()
        {
            Queen copy = new Queen(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return HavePositionsInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
        }
    }
}
