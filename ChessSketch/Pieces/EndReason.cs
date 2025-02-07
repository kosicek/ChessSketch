using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch.Pieces
{
    public enum EndReason
    {
        Checkmate,
        Stalemate,
        FiftyMoveRule,
        InsufficientMaterial,
        Threefoldrepetition
    }
}
