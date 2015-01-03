using System;
using System.Collections.Generic;
using System.Linq;

namespace Slide08
{
    public class Edge
    {
        public readonly Node First;
        public readonly Node Second;
        public Edge(Node first, Node second)
        {
            this.First = first;
            this.Second = second;
        }
        public bool IsIncident(Node node)
        {
            return First == node || Second == node;
        }
        public Node OtherNode(Node node)
        {
            if (!IsIncident(node)) throw new ArgumentException();
            if (First == node) return Second;
            return First;
        }
    }

    public class Node
    {
        readonly List<Edge> edges = new List<Edge>();
        public IEnumerable<Node> IncidentNodes
        {
            get
            {
                return edges.Select(z => z.OtherNode(this));
            }
        }
        public IEnumerable<Edge> IncidentEdges
        {
            get
            {
                foreach (var e in edges) yield return e;
            }
        }
        public static Edge Connect(Node node1, Node node2, Graph graph) 
        {
            if (!graph.Contains(node1) || !graph.Contains(node2)) throw new ArgumentException();
            var edge = new Edge(node1, node2);
            node1.edges.Add(edge);
            node2.edges.Add(edge);
            return edge;
        }
    }

    public class Graph : IEnumerable<Node>
    {
        private Node[] nodes;
        public Graph(int nodesCount)
        {
            nodes = new Node[nodesCount];
        }

        public int Length { get { return nodes.Length; } }

        public Node this[int index] { get { return nodes[index]; } }

        public IEnumerator<Node> GetEnumerator()
        {
            foreach (var node in nodes) yield return node;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Connect(int index1, int index2)
        {
            Node.Connect(nodes[index1], nodes[index2], this);
        }

        public IEnumerable<Edge> Edges
        {
            get
            {
                return nodes.SelectMany(z => z.IncidentEdges).Distinct();
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            Dictionary<Node, string> captions = new Dictionary<Node, string>();
            var graph = new Graph(10);
            captions[graph[0]] = "0";
        }
    }
}