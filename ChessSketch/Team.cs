using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public enum Team
    {
        None,
        White,
        Black
    }

    public static class TeamExtensions
    {
        public static Team Enemy(this Team team)
        {
            switch (team)
            {
                case Team.White:
                    return Team.Black;
                case Team.Black:
                    return Team.White;
                default: 
                    return Team.None;
            }
        }
    }
}
