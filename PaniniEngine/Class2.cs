﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaniniEngine.Graphs
{
    public enum GraphNodeColor : byte
    {
        White, Gray, Black
    }

    public class GraphNode<T> : IComparable<GraphNode<T>>
        where T : IComparable<T>
    {
        public T Key { get; set; }
        public int Distance { get; set; }
        public GraphNode<T> Predecessor { get; set; }
        public GraphNodeColor Color { get; set; }
        public int FinishingTime { get; internal set; }

        public int CompareTo(GraphNode<T> other)
        {
            return Key.CompareTo(other.Key);
        }
    }

    public class Graph<T>
        where T : IComparable<T>
    {
        public List<GraphNode<T>> V { get; set; }
        public List<List<GraphNode<T>>> Adj { get; set; }
    }

    public class GraphManager
    {
        public void BFS<T>(Graph<T> g, GraphNode<T> s)
            where T : IComparable<T>
        {
            foreach (var u in g.V)
            {
                if (u != s)
                {
                    u.Color = GraphNodeColor.White;
                    u.Distance = -1;
                    u.Predecessor = null;
                }
            }
            s.Color = GraphNodeColor.Gray;
            s.Distance = 0;
            s.Predecessor = null;
            Queue<GraphNode<T>> q = new Queue<GraphNode<T>>();
            q.Enqueue(s);
            while (q.Count != 0)
            {
                var u = q.Dequeue();
                int index = g.V.IndexOf(u); // Posiblemente esté haciendo al algoritmo lento.
                foreach (var v in g.Adj[index])
                {
                    if (v.Color == GraphNodeColor.White)
                    {
                        v.Color = GraphNodeColor.Gray;
                        v.Distance = u.Distance + 1;
                        v.Predecessor = u;
                        q.Enqueue(v);
                    }
                }
                u.Color = GraphNodeColor.Black;
            }
        }

        private int time;

        private void DFS_Visit<T>(Graph<T> g, GraphNode<T> u)
            where T : IComparable<T>
        {
            time++;
            u.Distance = time;
            u.Color = GraphNodeColor.Gray;
            int index = g.V.IndexOf(u);
            foreach (var v in g.Adj[index])
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

        public void DFS<T>(Graph<T> g)
            where T : IComparable<T>
        {
            foreach (var u in g.V)
            {
                u.Color = GraphNodeColor.White;
                u.Predecessor = null;
            }
            time = 0;
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