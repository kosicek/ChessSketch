using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class King : ChessPiece
    {
        public override Piecetype Type => Piecetype.King;

        public override Team Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        { Direction.Up, Direction.Down, Direction.Left, Direction.Right, Direction.DiagonalUpRight, Direction.DiagonalUpLeft, Direction.DiagonalDownRight, Direction.DiagonalDownLeft };

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

        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            foreach (Direction dir in dirs)
            {
                // checks 1 square to each direction
                Position to = from + dir;

                if (!Board.InBounds(to))
                {
                    continue;
                }

                if (board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            foreach (Position to in MovePositions(from, board))
            {
                yield return new NormalMove(from, to);
            }
        }

        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return MovePositions(from, board).Any(to =>
            {
                ChessPiece piece = board[to];
                return piece != null && piece.Type == Piecetype.King;
            });
        }
    }
}
