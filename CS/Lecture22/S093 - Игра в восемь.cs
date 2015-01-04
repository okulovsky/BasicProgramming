using System;
using System.Collections.Generic;
using System.Linq;
using Slide02;
using Slide06;
using Slide09;

namespace Slide91
{
    public class Game
    {
        const int Size = 3;
        public int[,] Data { get; set; }
        public Game(int[,] data)
        {
            Data = data;
        }
        public Game(Game original)
            :this((int[,])original.Data.Clone())
        {

        }

        IEnumerable<Point> Rectangle(int xmin, int xmax, int ymin, int ymax)
        {
            for (int x = xmin; x <= xmax; x++)
                for (int y = ymin; y <= ymax; y++)
                    yield return new Point { X = x, Y = y };
        }

        IEnumerable<Point> GamePoints
        {
            get
            {
                return Rectangle(0, Size - 1, 0, Size - 1);
            }
        }

        public Game Move(int dx, int dy)
        {
            var point = GamePoints
                .Where(p => Data[p.X, p.Y] == 0)
                .Where(p => p.X+dx >=0 && p.X+dx<Size && p.Y+dy>=0 && p.Y+dy<Size)
                .FirstOrDefault();
            if (point == null) return null;

            var newGame = new Game(this);
            newGame.Data[point.X, point.Y] = Data[point.X + dx, point.Y + dy];
            newGame.Data[point.X + dx, point.Y + dy] = Data[point.X, point.Y];
            return newGame;
        }

        public IEnumerable<Game> AllAdjacentGames()
        {
            return 
                Rectangle(-1,1,-1,1)
                .Where(point => point.X == 0 || point.Y == 0)
                .Select(point => Move(point.X, point.Y))
                .Where(game => game != null);
        }

        public override bool Equals(object obj)
        {
            var game = obj as Game;
            return GamePoints
                .All(point => Data[point.X, point.Y] == game.Data[point.X, point.Y]);
        }

        public override int GetHashCode()
        {
            return GamePoints
                .Select(point => (point.X * Size + point.Y) * 7 * Data[point.X, point.Y])
                .Sum();
        }

        public void Print()
        {
            var str = GamePoints
                .GroupBy(z => z.Y)
                .Select(row => row.Select(point => Data[point.X, point.Y].ToString()).Aggregate((a, b) => a + " " + b))
                .Aggregate((a, b) => a + "\n" + b);
            Console.WriteLine(str);
            Console.WriteLine();
        }
    }

    class Program
    {
        public static void Main()
        {
            var start = new Game(new[,] {
                { 1, 2, 3 }, 
                { 0, 7, 6 },
                { 4, 5, 8 }});

            var target = new Game(new[,]{
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 0}});

            var visited = new HashSet<Game>();
            var queue = new Queue<Game>();
            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                var game = queue.Dequeue();
                if (visited.Contains(game)) 
                    continue;
                visited.Add(game);
               // game.Print();
                if (game.Equals(target)) break;
                foreach (var nextGame in game.AllAdjacentGames().Where(g=>!visited.Contains(g)))
                    queue.Enqueue(nextGame);
    
            }
        }

    }
}