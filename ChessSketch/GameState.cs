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
            return piece.GetMoves(position, Board);
        }

        public void MakeMove(Move move)
        {
            move.Execute(Board);
            ToMove = ToMove.Enemy();
        }
    }
}
