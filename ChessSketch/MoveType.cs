using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public enum MoveType
    {
        Normal,
        CastleKS,
        CastleQS,
        PawnPromotion,
        DoublePawn,
        Enpassant
    }
}
