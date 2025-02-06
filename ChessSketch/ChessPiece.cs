using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public abstract class ChessPiece
    {
        private bool _hasMoved = false;
        public abstract Team Color { get; }
        public abstract Piecetype Type { get; }

        public bool HasMoved
        {
            get { return _hasMoved; }
            set { _hasMoved = value; }
        }

        public abstract ChessPiece Copy();

    }
}
