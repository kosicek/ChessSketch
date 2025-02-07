using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public abstract class ChessPiece
    {
        private bool _hasMoved = false;
        public abstract Team Color { get; }
        public abstract Piecetype Type { get; }

        public bool HasMoved
        {
            get { return _hasMoved; }
            set { _hasMoved = value; }
        }

        public abstract ChessPiece Copy();

        public abstract IEnumerable<Move> GetMoves(Position from,Board board);

        protected IEnumerable<Position> HavePositionsInDir(Position from, Board board, Direction direction)
        {
            for (Position pos = from + direction; Board.InBounds(pos);pos += direction)
            {
                if (board.IsEmpty(pos))
                {
                    // If its empty we continue
                    yield return pos;
                    continue;
                }
                // Otherwise there is a piece in the position and we need to determine on which team it is
                ChessPiece piece = board[pos];

                if (piece.Color != Color)
                {
                    // if its an enemy piece then the position also reachable
                    yield return pos;
                }
                // if not it isnt
                yield break;
            }
        }

        protected IEnumerable<Position> HavePositionsInDirs(Position from, Board board, Direction[] directions)
        {
            return directions.SelectMany(dir => HavePositionsInDir(from, board, dir));
        }
    }
}
