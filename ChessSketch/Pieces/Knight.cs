using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class Knight : ChessPiece
    {
        public override Piecetype Type => Piecetype.Knight;

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

        private static IEnumerable<Position> PotentionalToPositions(Position from)
        {
            foreach (Direction vDir in new Direction[] { Direction.Up, Direction.Down })
            {
                foreach (Direction hDir in new Direction[] { Direction.Left, Direction.Right })
                {
                    yield return from + 2 * vDir + hDir;
                    yield return from + 2 * hDir + vDir;
                }
            }
        }

        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            // Returns legal positions
            return PotentionalToPositions(from).Where(pos => Board.InBounds(pos) && (board.IsEmpty(pos) || board[pos].Color != Color));
        }


        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositions(from,board).Select(to  => new NormalMove(from,to));
        }
    }
}
