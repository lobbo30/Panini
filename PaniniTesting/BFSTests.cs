using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaniniEngine.Graphs;

namespace PaniniTesting
{
    [TestClass]
    public class BFSTests
    {
        [TestMethod]
        public void BFS()
        {
            var node1 = new GraphNode<char>() { Key = 'A' };
            var node2 = new GraphNode<char>() { Key = 'B' };
            var node3 = new GraphNode<char>() { Key = 'C' };
            var node4 = new GraphNode<char>() { Key = 'D' };
            var node5 = new GraphNode<char>() { Key = 'E' };
            var node6 = new GraphNode<char>() { Key = 'F' };

            Graph<char> grafo = new Graph<char>()
            {
                V = new Dictionary<char, GraphNode<char>>()
                {
                    { node1.Key, node1 },
                    { node2.Key, node2 },
                    { node3.Key, node3 },
                    { node4.Key, node4 },
                    { node5.Key, node5 },
                    { node6.Key, node6 }
                },
                Adj = new Dictionary<GraphNode<char>, List<GraphNode<char>>>()
                {
                    { node1, new List<GraphNode<char>>() { node2, node4 } },
                    { node2, new List<GraphNode<char>>() { node3, node4 } },
                    { node3, new List<GraphNode<char>>() { node1 } },
                    { node4, new List<GraphNode<char>>() { node5, node6 } },
                    { node5, new List<GraphNode<char>>() },
                    { node6, new List<GraphNode<char>>() { node2 } }
                }
            };

            GraphManager gm = new GraphManager();
            gm.BFS(grafo, node3);

            Assert.IsTrue(grafo.V.Values.All(v => v.Color == GraphNodeColor.Black));
        }

        [TestMethod]
        public void BFS_WithBigNumberOfNodes()
        {
            const int number = 1000;
            Dictionary<int, GraphNode<int>> verteces = new Dictionary<int, GraphNode<int>>();
            for (int i = 0; i < number; i++)
            {
                verteces.Add(i, new GraphNode<int>() { Key = i });
            }

            Random random = new Random();
            Dictionary<GraphNode<int>, List<GraphNode<int>>> adjs = new Dictionary<GraphNode<int>, List<GraphNode<int>>>();
            for (int j = 0; j < number; j++)
            {
                List<GraphNode<int>> temp = new List<GraphNode<int>>();
                int listLength = random.Next(number);
                for (int i = 0; i < listLength; i++) // Se puede mejorar con un while. Hay menos nodos.
                {
                    int key = random.Next(number);
                    if (!temp.Contains(verteces[key])) // Esto hace que la prueba sea lenta. No es el algoritmo.
                    {
                        temp.Add(verteces[key]);
                    }
                }
                adjs.Add(verteces[j], temp);
            }

            Graph<int> grafo = new Graph<int>()
            {
                V = verteces,
                Adj = adjs
            };

            GraphManager gm = new GraphManager();
            gm.BFS(grafo, verteces[random.Next(number)]);

            Assert.IsTrue(grafo.V.Values.All(v => v.Color == GraphNodeColor.Black));
        }
    }
}
