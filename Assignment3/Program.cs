using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Point startingPoint;
         
            char[][] basicMaze = new char[11][];

            startingPoint = new Point(1, 1);

            basicMaze[0] = "WWWWWWWWWWWWW".ToCharArray();
            basicMaze[1] = "W     W     W".ToCharArray();
            basicMaze[2] = "W WWW W WWW W".ToCharArray();
            basicMaze[3] = "W W       W W".ToCharArray();
            basicMaze[4] = "W WWWWWWW WWW".ToCharArray();
            basicMaze[5] = "W   W   W   W".ToCharArray();
            basicMaze[6] = "WWW W WWW   W".ToCharArray();
            basicMaze[7] = "W     W   WEW".ToCharArray();
            basicMaze[8] = "W WWWWW W WWW".ToCharArray();
            basicMaze[9] = "W       W   W".ToCharArray();
            basicMaze[10] = "WWWWWWWWWWWWW".ToCharArray();

            Maze maze = new Maze(startingPoint.Row, startingPoint.Column, basicMaze);

            string mazeOutput = maze.BreadthFirstSearch();
            Console.WriteLine(mazeOutput);
            Console.ReadKey();
        }
    }
}
