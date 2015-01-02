using System;
using System.Collections.Generic;
using System.Linq;

namespace Slide02
{
    enum State
    {
        Empty,
        Wall,
        Visited
    };

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

    }
    public class Program
    {

        static string[] labyrinth = new string[]
        {
            " X  X     ",
            " X XX XXXX",
            "    X     ",
            " XXXXX X X",
            " X   X X X",
            "   X   X  ",
        };

        static void Print(State[,] map)
        {
            return;
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            for (int x = 0; x < map.GetLength(0) + 2; x++)
                Console.Write("X");
            Console.WriteLine();
            for (int y = 0; y < map.GetLength(1); y++)
            {
                Console.Write("X");
                for (int x = 0; x < map.GetLength(0); x++)
                    switch (map[x, y])
                    {
                        case State.Wall: Console.Write("X"); break;
                        case State.Empty: Console.Write(" "); break;
                        case State.Visited: Console.Write("."); break;
                    }
                Console.WriteLine("X");
            }
            for (int x = 0; x < map.GetLength(0) + 2; x++)
                Console.Write("X");
            Console.ReadKey();
        }

        static void Main()
        {
            var map = new State[labyrinth[0].Length, labyrinth.Length];

            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                    map[x, y] = labyrinth[y][x] == ' ' ? State.Empty : State.Wall;

            map = new State[1000, 1000];

            var stack = new Stack<Point>();
            stack.Push(new Point { X = 0, Y = 0 });
            while (stack.Count != 0)
            {
                 var point = stack.Pop();
                if (point.X < 0 || point.X >= map.GetLength(0) || point.Y < 0 || point.Y >= map.GetLength(1)) continue;
                if (map[point.X, point.Y] != State.Empty) continue;
                map[point.X, point.Y] = State.Visited;
                Print(map);

                stack.Push(new Point { X = point.X, Y = point.Y - 1 });
                stack.Push(new Point { X = point.X, Y = point.Y + 1 });
                stack.Push(new Point { X = point.X - 1, Y = point.Y });
                stack.Push(new Point { X = point.X + 1, Y = point.Y });
                
            }
        }
    }
}