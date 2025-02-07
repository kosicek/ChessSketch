using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public static class Images
    {
        private static readonly Dictionary<Piecetype, Image> whiteSources = new Dictionary<Piecetype, Image>()
        {

            {Piecetype.Pawn, Image.FromFile("Assets/White_Pawn.png")},
            {Piecetype.Bishop, Image.FromFile("Assets/White_Bishop.png")},
            {Piecetype.Knight, Image.FromFile("Assets/White_Knight.png")},
            {Piecetype.Rook, Image.FromFile("Assets/White_Rook.png")},
            {Piecetype.Queen, Image.FromFile("Assets/White_Queen.png")},
            {Piecetype.King, Image.FromFile("Assets/White_King.png")}

        };

        private static readonly Dictionary<Piecetype, Image> blackSources = new Dictionary<Piecetype, Image>()
        {

            {Piecetype.Pawn, Image.FromFile("Assets/Black_Pawn.png")},
            {Piecetype.Bishop, Image.FromFile("Assets/Black_Bishop.png")},
            {Piecetype.Knight, Image.FromFile("Assets/Black_Knight.png")},
            {Piecetype.Rook, Image.FromFile("Assets/Black_Rook.png")},
            {Piecetype.Queen, Image.FromFile("Assets/Black_Queen.png")},
            {Piecetype.King, Image.FromFile("Assets/Black_King.png")}

        };

        public static Image GetImage(Team color, Piecetype type)
        {
            switch (color)
            {
                case Team.White:
                    return whiteSources[type];
                case Team.Black:
                    return blackSources[type];
                default:
                    return null;
            }
        }

        public static Image GetImage(ChessPiece piece)
        {
            // Overload on previous method
            if (piece == null)
            {
                return null;
            }

            return GetImage(piece.Color, piece.Type);
        }
    }
}
