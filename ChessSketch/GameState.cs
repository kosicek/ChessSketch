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
    }
}
