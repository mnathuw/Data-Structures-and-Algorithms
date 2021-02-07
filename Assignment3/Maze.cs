using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Maze
    {
        public Point StartingPoint { get; private set; }
        public int RowLength { get; private set; }
        public int ColumnLength { get; private set; }
        private char[][] mazeMatrix;
        private Stack<Point> stackPath;
        private Queue<RecurPoint> queuePoint;
        private bool isRunned = false;

        public Maze(string filename)
        {
            if (File.Exists(@filename))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@filename);
                string firstLine = file.ReadLine();

                this.RowLength = int.Parse(firstLine.Split(' ')[0]);
                this.ColumnLength = int.Parse(firstLine.Split(' ')[1]);

                string secondLine = file.ReadLine();

                this.StartingPoint = new Point(
                    int.Parse(secondLine.Split(' ')[0]),
                    int.Parse(secondLine.Split(' ')[1])
                );

                this.mazeMatrix = new char[RowLength][];
                for (int i = 0; i < RowLength; i++)
                {
                    var line = file.ReadLine();
                    if (line == null) throw new IndexOutOfRangeException();
                    this.mazeMatrix[i] = new char[ColumnLength];
                    var splitted = line.ToCharArray();
                    if (splitted.Length != ColumnLength) throw new IndexOutOfRangeException();
                    for (int j = 0; j < ColumnLength; j++)
                    {
                        this.mazeMatrix[i][j] = splitted[j];
                    }
                }
                this.stackPath = new Stack<Point>();
            }
            else
            {
                throw new IOException("Invalid filename");
            }
        }

        public Maze(int startingRow, int startingColumn, char[][] existingMaze)
        {
            this.StartingPoint = new Point(startingRow, startingColumn);
            this.stackPath = new Stack<Point>();
            this.RowLength = existingMaze.Length;
            this.ColumnLength = existingMaze[0].Length;

            if (startingRow < 0 ||
                startingRow >= existingMaze.Length ||
                startingColumn < 0 ||
                startingColumn >= existingMaze[0].Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (existingMaze[startingRow][startingColumn] == 'W' ||
                existingMaze[startingRow][startingColumn] == 'E')
            {
                throw new ApplicationException();
            }

            this.mazeMatrix = existingMaze;
        }

        public char[][] GetMaze()
        {
            return this.mazeMatrix;
        }
        public Stack<Point> GetPathToFollow()
        {
            if (!isRunned) throw new ApplicationException();
            Stack<Point> rotatedStack = new Stack<Point>();
            for (var node = stackPath.Head; node != null; node = node.Previous)
            {
                rotatedStack.Push(node.Element);
            }

            Stack<Point> clonedStack = new Stack<Point>();
            for (var node = rotatedStack.Head; node != null; node = node.Previous)
            {
                clonedStack.Push(node.Element);
            }
            return clonedStack;
        }

        public string PrintMaze()
        {
            string mazeStr = "";

            for (int i = 0; i < RowLength; i++)
            {
                mazeStr += new string(mazeMatrix[i]);
                if (i != RowLength - 1)
                {
                    mazeStr += "\n";
                }
            }
            return mazeStr;
        }

        private class RecurPoint : Point
        {
            public RecurPoint(int row, int column) : base(row, column)
            { }
            public RecurPoint(Point p) : base(p.Row, p.Column)
            { }
            public RecurPoint cameFrom { get; set; }
        }

        public string BreadthFirstSearch()
        {
            isRunned = true;
            char[][] tempMazeMatrix = mazeMatrix.Clone() as char[][];
            RecurPoint endPoint = new RecurPoint(0, 0);
            queuePoint = new Queue<RecurPoint>();
            int Try(Point startPoint)
            {
                var startRecurPoint = new RecurPoint(startPoint);
                queuePoint.Enqueue(startRecurPoint);

                while (queuePoint.Size > 0)
                {
                    var point = queuePoint.Dequeue();
                    mazeMatrix[point.Row][point.Column] = '.';
                    RecurPoint[] nextToPoint = new RecurPoint[4]
                    {
                        new RecurPoint(point.Row + 1, point.Column    ), // Bottom
                        new RecurPoint(point.Row    , point.Column + 1), // Right
                        new RecurPoint(point.Row    , point.Column -  1), // Left
                        new RecurPoint(point.Row  - 1, point.Column    ), // Top
                    };
                    foreach (var neighborPoint in nextToPoint)
                    {
                        var s = mazeMatrix[neighborPoint.Row][neighborPoint.Column];
                        if (s != 'V' && s != '.' && s != 'W')
                        {
                            neighborPoint.cameFrom = point;
                            if (s == 'E')
                            {
                                endPoint = neighborPoint;
                                return 1;
                            }
                            else
                            {
                                tempMazeMatrix[neighborPoint.Row][neighborPoint.Column] = 'V';
                            }
                            queuePoint.Enqueue(neighborPoint);
                        }
                    }
                    tempMazeMatrix[point.Row][point.Column] = 'V';
                    

                }
                return 0;
            }


            int result = Try(StartingPoint);
            string resultReport = "";

            if (result == 1)
            {
                RecurPoint endPointClone = new RecurPoint(endPoint.Row, endPoint.Column);
                Point pathPoint;
                do
                {
                    pathPoint = new Point(endPoint.Row, endPoint.Column);
                    stackPath.Push(pathPoint);
                    if (tempMazeMatrix[pathPoint.Row][ pathPoint.Column] != 'E')
                    {
                        tempMazeMatrix[pathPoint.Row][ pathPoint.Column] = '.';
                    }
                    endPoint = endPoint.cameFrom;
                } while (endPoint != null);

                // var endPoint
                for (var p = stackPath.Head; p != null; p = p.Previous)
                {
                    resultReport += "\n" + p.Element;
                }
                resultReport = String.Format("Path to follow from Start {0} to Exit {1} - {2} steps:", StartingPoint, endPointClone, stackPath.Size) + resultReport;
            }
            else
            {
                resultReport += "No exit found in maze!\n";
            }
            resultReport += "\n";
            for (int i = 0; i < RowLength; i++)
            {
                for (int j = 0; j < ColumnLength; j++)
                {
                    resultReport += tempMazeMatrix[i][j];
                }
                resultReport += "\n";
            }
            resultReport = resultReport.Remove(resultReport.Length - 1);
            return resultReport;
        }

    }
}

