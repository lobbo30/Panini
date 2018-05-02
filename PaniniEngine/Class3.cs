using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaniniEngine.Graphs3
{
    public enum VertexColor : byte
    {
        White, Gray, Black
    }

    public class Vertex<T> : IEquatable<Vertex<T>>
        where T : IComparable<T>
    {
        public T Key { get; set; }
        public Vertex<T> Predecessor { get; set; }
        public VertexColor Color { get; set; }
        public List<Vertex<T>> Adj { get; set; }

        public int Distance { get; set; }

        public int DiscoveryTime { get; set; }
        public int FinishingTime { get; set; }

        public bool Equals(Vertex<T> other)
        {
            if (other == null)
            {
                return false;
            }
            if (Key.Equals(other.Key) && Adj.Equals(other.Adj))
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Vertex<T> vertex = obj as Vertex<T>;
            if (vertex == null)
            {
                return false;
            }
            else
            {
                return Equals(vertex);
            }
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public static bool operator == (Vertex<T> vertex1, Vertex<T> vertex2)
        {
            if ((object)vertex1 == null || (object)vertex2 == null)
            {
                return object.Equals(vertex1, vertex2);
            }
            return vertex1.Equals(vertex2);
        }

        public static bool operator != (Vertex<T> vertex1, Vertex<T> vertex2)
        {
            if ((object)vertex1 == null || (object)vertex2 == null)
            {
                return !object.Equals(vertex1, vertex2);
            }
            return !vertex1.Equals(vertex2);
        }
    }

    public class Graph<T> : IEquatable<Graph<T>>
        where T : IComparable<T>
    {
        public IDictionary<T, Vertex<T>> V { get; set; }

        public bool Equals(Graph<T> other)
        {
            if (other == null)
            {
                return false;
            }
            if (V.Equals(other.V))
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Graph<T> graph = obj as Graph<T>;
            if (graph == null)
            {
                return false;
            }
            else
            {
                return Equals(graph);
            }
        }

        public override int GetHashCode()
        {
            return V.GetHashCode();
        }

        public static bool operator == (Graph<T> graph1, Graph<T> graph2)
        {
            if ((object)graph1 == null || (object)graph2 == null)
            {
                return object.Equals(graph1, graph2);
            }
            return graph1.Equals(graph2);
        }

        public static bool operator != (Graph<T> graph1, Graph<T> graph2)
        {
            if ((object)graph1 == null || (object)graph2 == null)
            {
                return !object.Equals(graph1, graph2);
            }
            return !graph1.Equals(graph2);
        }
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
                foreach (var v in g.V[u.Key].Adj)
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

        private static int time;

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

        private void DFS_Visit<T>(Graph<T> g, Vertex<T> u)
            where T : IComparable<T>
        {
            time++;
            u.DiscoveryTime = time;
            u.Color = VertexColor.Gray;
            foreach (var v in g.V[u.Key].Adj)
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
    }
}
