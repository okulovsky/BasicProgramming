using System;
using System.Collections.Generic;
using System.Linq;

using Slide06;

namespace Slide09
{
    public static class NodeExtensions
    {
        public static IEnumerable<Node> DepthSearch(this Node startNode)
        {
            var visited = new Dictionary<Node, bool>();
            var stack = new Stack<Node>();
            stack.Push(startNode);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                if (visited.ContainsKey(node)) continue;
                visited[node] = true;
                yield return node;
                foreach (var incidentNode in node.IncidentNodes)
                    stack.Push(incidentNode);
            }
        }

        public static IEnumerable<Node> BreadthSearch(this Node startNode)
        {
            var visited = new Dictionary<Node, bool>();
            var stack = new Queue<Node>();
            stack.Enqueue(startNode);
            while (stack.Count != 0)
            {
                var node = stack.Dequeue();
                if (visited.ContainsKey(node)) continue;
                visited[node] = true;
                yield return node;
                foreach (var incidentNode in node.IncidentNodes)
                    stack.Enqueue(incidentNode);
            }
        }
    }

    class Program
    {
        public static void Main()
        {
            Graph graph = new Graph(5);
            graph.Connect(0, 1);
            graph.Connect(0, 2);
            graph.Connect(1, 3);
            graph.Connect(1, 4);
            graph.Connect(2, 3);
            graph.Connect(3, 4);

            Dictionary<Node,int> captions=new Dictionary<Node,int>();
            for (int i = 0; i < graph.Length; i++)
                captions[graph[i]] = i;

            foreach (var e in graph[0].DepthSearch())
                Console.Write("{0} ", captions[e]);
            Console.WriteLine();

            foreach (var e in graph[0].BreadthSearch())
                Console.Write("{0} ", captions[e]);
            Console.WriteLine();

        }
    }
}