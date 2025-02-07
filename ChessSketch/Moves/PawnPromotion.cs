using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessSketch
{
    public class PawnPromotion : Move
    {
        public override MoveType Type => MoveType.PawnPromotion;

        public override Position FromPos { get; }

        public override Position ToPos { get; }

        private readonly Piecetype newType;

        public PawnPromotion(Position from, Position to, Piecetype newType)
        {
            FromPos = from;
            ToPos = to;
            this.newType = newType;
        }

        private ChessPiece CreatePromotionPiece(Team color)
        {
            switch (newType)
            {
                case Piecetype.Knight:
                    return new Knight(color);
                case Piecetype.Bishop:
                    return new Bishop(color);
                case Piecetype.Rook:
                    return new Rook(color);
                default: 
                    return new Queen(color);
            }
        }

        public override void Execute(Board board)
        {

            // For some reason after the first promotion this triggers weirdly since it promotes and then i think checks again 
            // so its needed to recheck prior steps in this D: at its current state it will delete a piece from where the last pawn promoted because
            ChessPiece pawn = board[FromPos]; // <-- 2. which means this is getting checked wrongly and i fucked up somewhere... Fun!
            board[FromPos] = null;              // So scenario A. which i suspect would be it gets checked again whilst it already promoted? scenario B. Dark magic needs more debug!
            try
            {
                ChessPiece promotionPiece = CreatePromotionPiece(pawn.Color); // <-- 1. this is null after first promotion 


                promotionPiece.HasMoved = true;
                board[ToPos] = promotionPiece;
            }
            catch
            {
               // MessageBox.Show("something weird has happened");
            }
        }
    }
}
