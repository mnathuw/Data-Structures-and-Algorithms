using System;

namespace Assignment3
{
    public class Point
    {
            public int Row { get; private set; }
            public int Column { get; private set; }
            public Point ParentPoint { get; set; }
            
            public Point(int row, int column, Point parentPoint = null)
            {
                Row = row;
                Column = column;
                ParentPoint = parentPoint;
            }
            
            public override string ToString()
            {
                return String.Format("[{0}, {1}]", Row, Column);
            }
     }
}
