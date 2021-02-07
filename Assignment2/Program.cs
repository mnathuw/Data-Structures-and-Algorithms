using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            var maze = new Maze("C:\\Users\\foure\\OneDrive\\Desktop\\BIT5\\Data Structure\\Assignment2\\simpleWithExit.maze");
            Console.WriteLine(maze.PrintMaze());
            //Console.WriteLine(maze.DepthFirstSearch());
            Console.ReadKey();
        }
    }
}
