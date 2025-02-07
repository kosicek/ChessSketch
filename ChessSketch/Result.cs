using ChessSketch.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class Result
    {
    public Team Winner { get; }
    public EndReason Reason { get; }

    public Result(Team winner, EndReason reason)
        {
            Winner = winner;
            Reason = reason;
        }   

    public static Result Win(Team winner)
        {
            return new Result(winner,EndReason.Checkmate);
        }

    public static Result Draw(EndReason reason)
        {
            return new Result(Team.None, reason);
        }

    }

}
