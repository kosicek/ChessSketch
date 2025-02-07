using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class Board
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
        private readonly ChessPiece[,] pieces = new ChessPiece[8, 8];

        public ChessPiece this[int row, int column]
        {
            get { return pieces[row, column]; }
            set { pieces[row, column] = value; }
        }

        public ChessPiece this[Position pos]
        {
            get { return this[pos.Row, pos.Column]; }
            set { this[pos.Row, pos.Column] = value; }
        }

        public static Board Intial()
        {
            Board board = new Board();
            board.AddStartPieces();
            return board;
        }

        private void AddStartPieces()
        {

            this[0, 0] = new Rook(Team.Black);
            this[0, 1] = new Knight(Team.Black);
            this[0, 2] = new Bishop(Team.Black);
            this[0, 3] = new Queen(Team.Black);
            this[0, 4] = new King(Team.Black);
            this[0, 5] = new Bishop(Team.Black);
            this[0, 6] = new Knight(Team.Black);
            this[0, 7] = new Rook(Team.Black);

            this[7, 0] = new Rook(Team.White);
            this[7, 1] = new Knight(Team.White);
            this[7, 2] = new Bishop(Team.White);
            this[7, 3] = new Queen(Team.White);
            this[7, 4] = new King(Team.White);
            this[7, 5] = new Bishop(Team.White);
            this[7, 6] = new Knight(Team.White);
            this[7, 7] = new Rook(Team.White);
            for (int c = 0; c < 8; c++)
            {
                this[1, c] = new Pawn(Team.Black); 
                this[6, c] = new Pawn(Team.White);
            }
        }

        public static bool InBounds(Position Pos)
        {
            return Pos.Row >= 0 && Pos.Row < 8 && Pos.Column >= 0 && Pos.Column < 8;
        }

        public bool IsEmpty(Position pos) 
        {
            return this[pos] == null;
        }
    }
}
