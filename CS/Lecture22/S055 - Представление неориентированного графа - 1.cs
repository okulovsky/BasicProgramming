
using System;
using System.Collections.Generic;
using System.Linq;

namespace Slide055
{
    public class Node
    {
        private readonly List<Node> incidentNodes = new List<Node>();
        public IEnumerable<Node> IncidentNodes
        {
            get
            {
                foreach (var node in incidentNodes)
                    yield return node;
            }
        }
        public static void Connect(Node node1, Node node2, Graph graph)
        {
            if (!graph.Contains(node1) || !graph.Contains(node2)) throw new ArgumentException();
            node1.incidentNodes.Add(node2);
            node2.incidentNodes.Add(node1);
        }
    }

    public class Graph : IEnumerable<Node>
    {
        private Node[] nodes;
        public Graph(int nodesCount)
        {
            nodes = Enumerable.Range(0, nodesCount).Select(z => new Node()).ToArray();
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
    }

}