﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class Rook : ChessPiece
    {
        public override Piecetype Type => Piecetype.Rook;

        public override Team Color { get; }

        private static readonly Direction[] dirs = new Direction[] {Direction.Up,Direction.Down,Direction.Left, Direction.Right };


        public Rook(Team color)
        {
            Color = color;
        }

        public override ChessPiece Copy()
        {
            Rook copy = new Rook(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return HavePositionsInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
        }
    }
}
