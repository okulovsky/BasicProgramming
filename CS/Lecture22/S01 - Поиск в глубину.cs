using System;
using System.Linq;

namespace Slide01
{
    enum State
    {
        Empty,
        Wall,
        Visited
    };

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
            for (int x = 0; x < map.GetLength(0)+2; x++)
                Console.Write("X");
            Console.WriteLine();
            for (int y = 0; y < map.GetLength(1); y++)
            {
                Console.Write("X");
                for (int x = 0; x < map.GetLength(0); x++)
                    switch (map[x,y])
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


        static void Visit(State[,] map, int x, int y)
        {
            if (x<0 || x>=map.GetLength(0)|| y<0 || y>=map.GetLength(1)) return;
            if (map[x,y] != State.Empty) return;
            map[x,y]= State.Visited;
            Print(map);

            Visit(map, x + 1, y);
            Visit(map, x - 1, y);
            Visit(map, x, y + 1);
            Visit(map, x, y - 1);
        }

        static void MainX()
        {
            var map = new State[labyrinth[0].Length,labyrinth.Length];
            
            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                    map[x, y] = labyrinth[y][x] == ' ' ? State.Empty : State.Wall;

            map = new State[1000, 1000];
            Print(map);
            Visit(map, 0, 0);
        }
    }
}