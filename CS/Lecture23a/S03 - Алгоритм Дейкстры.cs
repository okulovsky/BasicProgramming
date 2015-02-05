using System;
using System.Linq;
using System.Collections.Generic;

namespace Slide01
{
    class DijrstraData
    {
        public Node Previous { get; set; }
        public double PathLength { get; set; }
    }


    static class ArgMinExtension
    {
        public static Tuple<TData,TGoal> ArgMin<TData,TGoal>(this IEnumerable<TData> sequence, Func<TData,TGoal> selector)
            where TGoal : IComparable
        {
            TData argMin = default(TData);
            var min = default(TGoal);
            var firstTime = true;
            foreach (var data in sequence)
            {
                var goal = selector(data);
                if (firstTime || min.CompareTo(goal) > 0)
                {
                    argMin = data;
                    min = goal;
                    firstTime = false;
                }
            }
            if (firstTime) return null;
            return Tuple.Create(argMin, min);
        }

    }

    public class Program
    {

        static List<Node> DijkstraAlgorithm(Graph graph, Dictionary<Edge,double> weights, Node start, Node end)
        {
            var visited = new Dictionary<Node, DijrstraData>() 
            {
                { start, new DijrstraData { PathLength=0, Previous=null } }
            };

            while (true)
            {
                var nextNodeData = graph.Nodes
                    .Where(node => !visited.ContainsKey(node))
                    .SelectMany(node => node.IncidentEdges
                                            .Select(edge => new
                                                {
                                                    Node = node,
                                                    From = edge.OtherNode(node),
                                                    Weight = weights[edge]
                                                }))
                                            .Where(data=>visited.ContainsKey(data.From))
                    .ArgMin(data => visited[data.From].PathLength + data.Weight);

                if (nextNodeData == null) return null;

                visited[nextNodeData.Item1.Node] = new DijrstraData
                {
                    PathLength = nextNodeData.Item2,
                    Previous = nextNodeData.Item1.From
                };

                if (nextNodeData.Item1.Node == end) break;
            }

            var result = new List<Node>();
            while (end != null)
            {
                result.Add(end);
                end = visited[end].Previous;
            }
            result.Reverse();
            return result;
        }
    }
}