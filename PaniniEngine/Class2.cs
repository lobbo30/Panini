using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaniniEngine
{
    public enum GraphNodeColor : byte
    {
        White, Gray, Black
    }

    public class GraphNode
    {
        public double Distance { get; set; }
        public GraphNode Predecessor { get; set; }
        public GraphNodeColor Color { get; set; }
        public int FinishingTime { get; internal set; }
    }

    public class Graph
    {
        public List<GraphNode> V { get; set; }
        public List<GraphNode> Adj { get; set; }
    }

    public class GraphManager
    {
        public void BFS(Graph g, GraphNode s)
        {
            //g.V.Remove(s);
            foreach (var u in g.V)
            {
                u.Color = GraphNodeColor.White;
                u.Distance = double.MaxValue;
                u.Predecessor = null;
            }
            s.Color = GraphNodeColor.Gray;
            s.Distance = 0.0;
            s.Predecessor = null;
            Queue<GraphNode> q = new Queue<GraphNode>();
            q.Enqueue(s);
            while (q.Count != 0)
            {
                GraphNode u = q.Dequeue();
                foreach (var v in g.Adj)
                {
                    if (v.Color == GraphNodeColor.White)
                    {
                        v.Color = GraphNodeColor.Gray;
                        v.Distance = u.Distance + 1;
                        v.Predecessor = u;
                    }
                    q.Enqueue(v);
                }
                u.Color = GraphNodeColor.Black;
            }
        }

        private int time = 0;

        public void DFS_Visit(Graph g, GraphNode u)
        {
            time++;
            u.Distance = time;
            u.Color = GraphNodeColor.Gray;
            foreach (var v in g.Adj)
            {
                if (v.Color == GraphNodeColor.White)
                {
                    v.Predecessor = u;
                    DFS_Visit(g, v);
                }
            }
            u.Color = GraphNodeColor.Black;
            time++;
            u.FinishingTime = time;
        }

        public void DFS(Graph g)
        {
            foreach (var u in g.V)
            {
                u.Color = GraphNodeColor.White;
                u.Predecessor = null;
            }
            //int time = 0;
            foreach (var u in g.V)
            {
                if (u.Color == GraphNodeColor.White)
                {
                    DFS_Visit(g, u);
                }
            }
        }
    }
}
