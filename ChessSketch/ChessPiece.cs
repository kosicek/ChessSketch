using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    class ChessPiece
    {
        private bool _hasMoved = false;
        private string _team = "None"; // Black Or White
        private string _piece = "None"; // Official Names => King,Queen,Bishop,Rook,Knight,Pawn,Null

        public ChessPiece(string team, string piece)
        {
            this._team = Team;
            this._piece = Piece;
            this._hasMoved = false;
        }

        public string Team
        {
            get { return _team; }
            set { _team = value; }
        }

        public string Piece
        {
            get { return _piece; }
            set { _piece = value; }
        }

        public bool HasMoved
        {
            get { return _hasMoved; }
            set { _hasMoved = value; }
        }

        /*public ReturnArt()
        {
            if (_team != "Null" && _piece != "Null")
            {
                return new BitmapImage(new Uri("/Assets/" + _team + "_" + _piece + ".png", UriKind.Relative));
            }
            return null;
        }*/
    }
}
