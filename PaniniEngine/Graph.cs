using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaniniEngine.Graphs
{
    public enum VertexColor : byte
    {
        White, Gray, Black
    }

    public class Vertex<T> : IComparable<Vertex<T>>
        where T : IComparable<T>
    {
        public T Key { get; set; }
        public Vertex<T> Predecessor { get; set; }
        public VertexColor Color { get; set; }

        public int Distance { get; set; }

        public int DiscoveryTime { get; set; }
        public int FinishingTime { get; set; }

        public int CompareTo(Vertex<T> other)
        {
            return Key.CompareTo(other.Key);
        }
    }

    public class Graph<T>
        where T : IComparable<T>
    {
        public IDictionary<T, Vertex<T>> V { get; set; }
        public IDictionary<Vertex<T>, List<Vertex<T>>> Adj { get; set; }
    }

    public class GraphManager
    {
        public void BFS<T>(Graph<T> g, Vertex<T> s)
            where T : IComparable<T>
        {
            foreach (var u in g.V.Values)
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
            Queue<Vertex<T>> q = new Queue<Vertex<T>>();
            q.Enqueue(s);
            while (q.Count != 0)
            {
                var u = q.Dequeue();
                foreach (var v in g.Adj[u])
                {
                    if (v.Color == VertexColor.White)
                    {
                        v.Color = VertexColor.Gray;
                        v.Distance = u.Distance + 1;
                        v.Predecessor = u;
                        q.Enqueue(v);
                    }
                }
                u.Color = VertexColor.Black;
            }
        }

        private int time;

        private void DFS_Visit<T>(Graph<T> g, Vertex<T> u)
            where T : IComparable<T>
        {
            time++;
            u.DiscoveryTime = time;
            u.Color = VertexColor.Gray;
            foreach (var v in g.Adj[u])
            {
                if (v.Color == VertexColor.White)
                {
                    v.Predecessor = u;
                    DFS_Visit(g, v);
                }
            }
            u.Color = VertexColor.Black;
            time++;
            u.FinishingTime = time;
        }

        public void DFS<T>(Graph<T> g)
            where T : IComparable<T>
        {
            foreach (var u in g.V.Values)
            {
                u.Color = VertexColor.White;
                u.Predecessor = null;
            }
            time = 0;
            foreach (var u in g.V.Values)
            {
                if (u.Color == VertexColor.White)
                {
                    DFS_Visit(g, u);
                }
            }
        }

        public List<Vertex<T>> TopologicalSort<T>(Graph<T> g)
            where T : IComparable<T>
        {
            foreach (var u in g.V.Values)
            {
                u.Color = VertexColor.White;
                u.Predecessor = null;
            }
            time = 0;
            List<Vertex<T>> list = new List<Vertex<T>>();
            foreach (var u in g.V.Values)
            {
                if (u.Color == VertexColor.White)
                {
                    TopologicalSort_Visit(g, u, list);
                }
            }
            return list;
        }

        private void TopologicalSort_Visit<T>(Graph<T> g, Vertex<T> u, List<Vertex<T>> list)
            where T : IComparable<T>
        {
            time++;
            u.DiscoveryTime = time;
            u.Color = VertexColor.Gray;
            foreach (var v in g.Adj[u])
            {
                if (v.Color == VertexColor.White)
                {
                    v.Predecessor = u;
                    TopologicalSort_Visit(g, v, list);
                }
            }
            u.Color = VertexColor.Black;
            time++;
            u.FinishingTime = time;
            list.Insert(0, u);
        }
    }
}
