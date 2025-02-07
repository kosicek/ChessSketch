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

        private readonly Direction Foward;
        public Pawn(Team color)
        {
            Color = color;

            if (color == Team.White)
            {
                Foward = Direction.Up;
            }
            else
            if (color == Team.Black)
            {
                Foward = Direction.Down;
            }
        }

        public override ChessPiece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static bool CanMoveTo(Position pos, Board board)
        {
            return Board.InBounds(pos) && board.IsEmpty(pos);
        }

        private bool CanCaptureAt(Position pos, Board board)
        {
            if (!Board.InBounds(pos) || board.IsEmpty(pos))
            {
                return false;
            }

            return board[pos].Color != Color;
        }

        private static IEnumerable<Move> promotionMoves(Position from, Position to)
        {
            yield return new PawnPromotion(from, to, Piecetype.Knight);
            yield return new PawnPromotion(from, to, Piecetype.Bishop);
            yield return new PawnPromotion(from, to, Piecetype.Rook);
            yield return new PawnPromotion(from, to, Piecetype.Queen);
        }

        private IEnumerable<Move> FowardMoves(Position from, Board board)
        {
            Position oneMovePos = from + Foward;

            if (CanMoveTo(oneMovePos, board))
            {
                if (oneMovePos.Row == 0 || oneMovePos.Row == 7)
                {
                    foreach (Move promMove in promotionMoves(from, oneMovePos))
                    {
                        yield return promMove;
                    }
                }
                else
                {
                    yield return new NormalMove(from, oneMovePos);
                }

                Position twoMovesPos = oneMovePos + Foward;

                if (!HasMoved && CanMoveTo(twoMovesPos, board))
                {
                    yield return new NormalMove(from,twoMovesPos);
                }
            }

        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach (Direction dir in new Direction[] { Direction.Left, Direction.Right })
            {
                Position to = from + Foward + dir;

                if (CanCaptureAt(to, board))
                {
                    if (to.Row == 0 || to.Row == 7)
                    {
                        foreach (Move promMove in promotionMoves(from, to))
                        {
                            yield return promMove;
                        }
                    }
                    else
                    {
                        yield return new NormalMove(from, to);
                    }
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            // returns the combination of two
            return FowardMoves(from, board).Concat(DiagonalMoves(from, board));
        }

        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return DiagonalMoves(from, board).Any(move =>
            {
                ChessPiece piece = board[move.ToPos];
                return piece != null && piece.Type == Piecetype.King;
            });
        }
    }
}
