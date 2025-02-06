using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSketch
{
    public class Direction
    {
        public readonly static Direction Up = new Direction(-1, 0);
        public readonly static Direction Down = new Direction(1, 0);
        public readonly static Direction Left = new Direction(0, 1);
        public readonly static Direction Right = new Direction(0, -1);
        public readonly static Direction DiagonalUpRight = Up + Right;
        public readonly static Direction DiagonalUpLeft = Up + Left;
        public readonly static Direction DiagonalDownRight = Down + Right;
        public readonly static Direction DiagonalDownLeft = Down + Left;


        public int RowDelta { get; }
        public int ColumnDelta { get; }


        public Direction(int rowDelta, int columnDelta)
        {
            RowDelta = rowDelta;
            ColumnDelta = columnDelta;
        }

        public static Direction operator +(Direction Direction1, Direction Direction2) 
        {

            return new Direction(Direction1.RowDelta + Direction2.RowDelta, Direction1.ColumnDelta + Direction2.ColumnDelta);

        }

        public static Direction operator *(int Scalar, Direction Direction)
        {

            return new Direction(Scalar * Direction.RowDelta, Scalar * Direction.ColumnDelta);

        }
    }


}
