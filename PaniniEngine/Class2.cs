using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaniniEngine.Graphs2
{
    public enum VertexColor : byte
    {
        White, Gray, Black
    }

    public class Vertex
    {
        public int Key { get; set; }
        public Vertex Predecessor { get; set; }
        public VertexColor Color { get; set; }

        public int Distance { get; set; }

        public int DiscoveryTime { get; set; }
        public int FinishingTime { get; set; }

        public List<Edge> Adj { get; set; }
    }

    public class Edge
    {
        public Vertex U { get; set; }
        public Vertex V { get; set; }
        public double Weight { get; set; }
    }

    public class Graph
    {
        public Dictionary<int, Vertex> Vertices { get; set; }

        public bool DFSProcessed { get; set; } = false;
        public int Cycles { get; set; }
        public bool IsAcyclic
        {
            get
            {
                if (!DFSProcessed)
                {
                    throw new ArgumentException();
                }
                return (Cycles == 0);
            }
        }
    }

    public class GraphManager
    {
        public void BFS(Graph g, Vertex s)
        {
            foreach (var u in g.Vertices.Values)
            {
                if (u != s)
                {
                    u.Color = VertexColor.White;
                    u.Distance = -1;
                    u.Predecessor = null;
                }
            }
            s.Color = VertexColor.Gray;
            s.Distance = 0;
            s.Predecessor = null;
            Queue<Vertex> q = new Queue<Vertex>();
            q.Enqueue(s);
            while (q.Count != 0)
            {
                var u = q.Dequeue();
                foreach (var e in g.Vertices[u.Key].Adj)
                {
                    if (e.V.Color == VertexColor.White)
                    {
                        e.V.Color = VertexColor.Gray;
                        e.V.Distance = u.Distance + 1;
                        e.V.Predecessor = u;
                        q.Enqueue(e.V);
                    }
                }
                u.Color = VertexColor.Black;
            }
        }

        private static int time;

        public void DFS(Graph g)
        {
            foreach (var u in g.Vertices.Values)
            {
                u.Color = VertexColor.White;
                u.Predecessor = null;
            }
            time = 0;
            g.Cycles = 0;
            g.DFSProcessed = false;
            foreach (var u in g.Vertices.Values)
            {
                if (u.Color == VertexColor.White)
                {
                    DFS_Visit(g, u);
                }
            }
            g.DFSProcessed = true;
        }

        private void DFS_Visit(Graph g, Vertex u)
        {
            time++;
            u.DiscoveryTime = time;
            u.Color = VertexColor.Gray;
            foreach (var e in g.Vertices[u.Key].Adj)
            {
                if (e.V.Color == VertexColor.White)
                {
                    e.V.Predecessor = u;
                    DFS_Visit(g, e.V);
                }
                else if (e.V.Color == VertexColor.Gray)
                {
                    g.Cycles++;
                }
            }
            u.Color = VertexColor.Black;
            time++;
            u.FinishingTime = time;
        }

        public List<Vertex> TopologicalSort(Graph g)
        {
            if (!g.IsAcyclic)
            {
                throw new ArgumentException();
            }
            foreach (var u in g.Vertices.Values)
            {
                u.Color = VertexColor.White;
                u.Predecessor = null;
            }
            time = 0;
            //g.Cycles = 0;
            //g.DFSProcessed = false;
            List<Vertex> list = new List<Vertex>();
            foreach (var u in g.Vertices.Values)
            {
                if (u.Color == VertexColor.White)
                {
                    TopologicalSort_Visit(g, u, list);
                }
            }
            //g.DFSProcessed = true;
            return list;
        }

        private void TopologicalSort_Visit(Graph g, Vertex u, List<Vertex> list)
        {
            time++;
            u.DiscoveryTime = time;
            u.Color = VertexColor.Gray;
            foreach (var e in g.Vertices[u.Key].Adj)
            {
                if (e.V.Color == VertexColor.White)
                {
                    e.V.Predecessor = u;
                    TopologicalSort_Visit(g, e.V, list);
                }
                //else if (e.V.Color == VertexColor.Gray)
                //{
                //    g.Cycles++;
                //}
            }
            u.Color = VertexColor.Black;
            time++;
            u.FinishingTime = time;
            list.Insert(0, u);
        }
    }
}
