using ChessSketch.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class GameState
    {
        public Board Board { get; }
        public Team ToMove { get; private set; }

        public Result Result { get; private set; } = null;

        public GameState(Team player, Board board)
        {
            ToMove = player;
            Board = board;
        }

        public IEnumerable<Move> LegalMovesForPiece(Position position)
        {
            if (Board.IsEmpty(position) || Board[position].Color != ToMove)
            {
                return Enumerable.Empty<Move>();
            }

            ChessPiece piece = Board[position];
            IEnumerable<Move> moveCandidates = piece.GetMoves(position, Board);
            return moveCandidates.Where(move => move.IsLegal(Board));
        }

        public void MakeMove(Move move)
        {
            move.Execute(Board);
            ToMove = ToMove.Enemy();
            CheckForGameOver();
        }

        public IEnumerable<Move> AllLegalMovesFor(Team color)
        {
            IEnumerable<Move> moveCandidates = Board.PiecePositionsFor(color).SelectMany(pos =>
            {
                ChessPiece piece = Board[pos];
                return piece.GetMoves(pos, Board);
            }
            );

            return moveCandidates.Where(Move => Move.IsLegal(Board));
        }

        private void CheckForGameOver()
        {
            if (!AllLegalMovesFor(ToMove).Any())
            {
                if (Board.IsInCheck(ToMove))
                {
                    Result = Result.Win(ToMove.Enemy());
                }
                else
                {
                    Result = Result.Draw(EndReason.Stalemate);
                }
            }
        }

        public bool IsGameOver()
        {
            return Result != null;
        }
    }

}
