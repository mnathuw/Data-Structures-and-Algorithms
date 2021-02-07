using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Maze
    {
        public Point StartingPoint { get; private set; }
        public int RowLength { get; private set; }
        public int ColumnLength { get; private set; }
        private char[][] mazeMatrix;
        private Stack<Point> path;

        //public Maze(string fileName)
        //{
        //    try 
        //    {   
        //        string[] fileLines = File.ReadAllLines(fileName);

        //        string[] startpointText = fileLines[1].Split();

        //        StartingPoint = new Point(Convert.ToInt32(startpointText[0]),
        //                                    Convert.ToInt32(startpointText[1]));

        //        mazeMatrix = new char[fileLines.Length - 2][];

        //        for (int i = 2; i < fileLines.Length; i++)
        //        {​​​​​​
        //            mazeMatrix[i - 2] = fileLines[i].ToCharArray();
        //        }​​​​​​
        //    }
        //    catch
        //    {​​​​​​
        //        throw new ApplicationException();
        //    }​​​​​​
        //}​​​​​​

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
                this.path = new Stack<Point>();
            }
            else
            {
                throw new IOException("Invalid filename");
            }
        }

        public Maze(int startingRow, int startingColumn, char[][] existingMaze)
        {
            this.StartingPoint = new Point(startingRow, startingColumn);
            this.path = new Stack<Point>();
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
            //if (path.Size == 0) throw new ApplicationException();
            Stack<Point> rotatedStack = new Stack<Point>();
            for (var node = path.Head; node != null; node = node.Previous)
            {
                rotatedStack.Push(node.Element);
            }

            return rotatedStack;
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

        public string DepthFirstSearch()
        {
            //char[][] tempMazeMatrix = mazeMatrix.Clone() as char[][];

            int result = Try(StartingPoint);
            string resultReport = "";

            if (result == 1)
            {
                for (var p = path.Head; p != null; p = p.Previous)
                {
                    resultReport = "\n" + p.Element + resultReport;
                }
                resultReport = String.Format("Path to follow from Start {0} to Exit {1} - {2} steps:", StartingPoint, path.Top(), path.Size) + resultReport;
            }
            else
            {
                resultReport = "No exit found in maze!\n";
            }
            resultReport += "\n";
            for (int i = 0; i < RowLength; i++)
            {
                for (int j = 0; j < ColumnLength; j++)
                {
                    resultReport += mazeMatrix[i][j] + "";
                }
                if (i != RowLength - 1)
                {
                    resultReport += "\n";
                }
            }
            return resultReport;
        }

        int Try(Point point)
        {
            path.Push(point);
            if (mazeMatrix[point.Row][point.Column] == 'E') return 1;

            if (mazeMatrix[point.Row][point.Column] != ' ')
            {
                path.Pop();
                return 0;
            }

            mazeMatrix[point.Row][point.Column] = '.';


            Point[] nextToPoint = new Point[4]
            {
                    new Point(point.Row + 1, point.Column    ), // Bottom
                    new Point(point.Row    , point.Column + 1), // Left
                    new Point(point.Row - 1, point.Column    ), // Top
                    new Point(point.Row    , point.Column - 1), // Right
            };

            foreach (Point p in nextToPoint)
            {
                if (Try(p) == 1)
                {
                    return 1;
                }
            }
            mazeMatrix[point.Row][point.Column] = 'V';
            path.Pop();
            return 0;
        }
    }
}
