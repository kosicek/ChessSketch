using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    internal class Board
    {
        /*static public ChessPiece[,] ChessBoard = new ChessPiece[,]
        { { new ChessPiece("Black","Rook"), new ChessPiece("Black","Knight"), new ChessPiece("Black","Bishop"), new ChessPiece("Black","Queen"), new ChessPiece("Black","King"), new ChessPiece("Black","Bishop"), new ChessPiece("Black","Knight"), new ChessPiece("Black","Rook")}
        , { new ChessPiece("Black","Pawn"), new ChessPiece("Black","Pawn"), new ChessPiece("Black","Pawn"), new ChessPiece("Black","Pawn"), new ChessPiece("Black","Pawn"), new ChessPiece("Black","Pawn"), new ChessPiece("Black","Pawn"), new ChessPiece("Black","Pawn")}
        , { new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"),}
        , { new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"),}
        , { new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"),}
        , { new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"), new ChessPiece("Empty","Empty"),}
        , { new ChessPiece("White","Pawn"), new ChessPiece("White","Pawn"), new ChessPiece("White","Pawn"), new ChessPiece("White","Pawn"), new ChessPiece("White","Pawn"), new ChessPiece("White","Pawn"), new ChessPiece("White","Pawn"), new ChessPiece("White","Pawn")}
        , { new ChessPiece("White","Rook"), new ChessPiece("White","Knight"), new ChessPiece("White","Bishop"), new ChessPiece("White","Queen"), new ChessPiece("White","King"), new ChessPiece("White","Bishop"), new ChessPiece("White","Knight"), new ChessPiece("White","Rook")}
};*/
        public bool InBounds(Position Pos)
        {
            if (Pos.Row < 0 || Pos.Column < 0 || Pos.Row > 8 || Pos.Column > 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsEmpty(Position Pos) 
        {
            if 
        }
    }
}
