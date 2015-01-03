using System;
using System.Collections.Generic;
using System.Linq;

namespace Slide07
{
    public class Edge<TNodeData, TEdgeData>
    {
        public readonly Node<TNodeData,TEdgeData> First;
        public readonly Node<TNodeData,TEdgeData> Second;

        TEdgeData Data { get; set; }

        public Edge(Node<TNodeData,TEdgeData> first, Node<TNodeData,TEdgeData> second)
        {
            this.First = first;
            this.Second = second;
        }
        public bool IsIncident(Node<TNodeData,TEdgeData> node)
        {
            return First == node || Second == node;
        }
        public Node<TNodeData,TEdgeData> OtherNode(Node<TNodeData,TEdgeData> node)
        {
            if (!IsIncident(node)) throw new ArgumentException();
            if (First == node) return Second;
            return First;
        }
    }

    public class Node<TNodeData, TEdgeData>
    {
        readonly List<Edge<TNodeData, TEdgeData>> edges = new List<Edge<TNodeData, TEdgeData>>();
        public IEnumerable<Node<TNodeData, TEdgeData>> IncidentNodes
        {
            get
            {
                return edges.Select(z => z.OtherNode(this));
            }
        }
        public IEnumerable<Edge<TNodeData, TEdgeData>> IncidentEdges
        {
            get
            {
                foreach (var e in edges) yield return e;
            }
        }
        public static Edge<TNodeData, TEdgeData> Connect(Node<TNodeData, TEdgeData> node1, Node<TNodeData, TEdgeData> node2, Graph<TNodeData, TEdgeData> graph)
        {
            if (!graph.Contains(node1) || !graph.Contains(node2)) throw new ArgumentException();
            var edge = new Edge<TNodeData, TEdgeData>(node1, node2);
            node1.edges.Add(edge);
            node2.edges.Add(edge);
            return edge;
        }
    }

    public class Graph<TNodeData, TEdgeData> : IEnumerable<Node<TNodeData, TEdgeData>>
    {
        private Node<TNodeData, TEdgeData>[] nodes;
        public Graph(int nodesCount)
        {
            nodes = new Node<TNodeData, TEdgeData>[nodesCount];
        }

        public int Length { get { return nodes.Length; } }

        public Node<TNodeData, TEdgeData> this[int index] { get { return nodes[index]; } }

        public IEnumerator<Node<TNodeData, TEdgeData>> GetEnumerator()
        {
            foreach (var node in nodes) yield return node;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Connect(int index1, int index2)
        {
            Node<TNodeData, TEdgeData>.Connect(nodes[index1], nodes[index2], this);
        }

        public IEnumerable<Edge<TNodeData, TEdgeData>> Edges
        {
            get
            {
                return nodes.SelectMany(z => z.IncidentEdges).Distinct();
            }
        }
    }
}