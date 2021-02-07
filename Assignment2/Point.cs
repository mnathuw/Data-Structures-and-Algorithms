namespace Assignment2
{
    public class Point
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Point(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", Row, Column);
        }
    }
}
