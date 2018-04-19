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
                V = new List<GraphNode<char>>() { node1, node2, node3, node4, node5, node6 },
                Adj = new List<List<GraphNode<char>>>()
                {
                    new List<GraphNode<char>>() { node2, node4 },
                    new List<GraphNode<char>>() { node3, node4 },
                    new List<GraphNode<char>>() { node1 },
                    new List<GraphNode<char>>() { node5, node6 },
                    new List<GraphNode<char>>(),
                    new List<GraphNode<char>>() { node2 }
                }
            };

            GraphManager gm = new GraphManager();
            gm.BFS(grafo, node3);

            Assert.IsTrue(grafo.V.All(v => v.Color == GraphNodeColor.Black));
        }

        [TestMethod]
        public void BFS_WithBigNumberOfNodes()
        {
            const int number = 10000;
            List<GraphNode<int>> nodes = new List<GraphNode<int>>();
            for (int i = 0; i < number; i++)
            {
                nodes.Add(new GraphNode<int>() { Key = i });
            }

            Random random = new Random();
            List<List<GraphNode<int>>> adjs = new List<List<GraphNode<int>>>();
            for (int j = 0; j < number; j++)
            {
                List<GraphNode<int>> temp = new List<GraphNode<int>>();
                for (int i = 0; i < random.Next(number); i++)
                {
                    temp.Add(nodes[random.Next(number)]);
                }
                adjs.Add(temp);
            }
           
            Graph<int> grafo = new Graph<int>()
            {
                V = nodes,
                Adj = adjs
            };

            GraphManager gm = new GraphManager();
            gm.BFS(grafo, nodes[random.Next(number)]);

            Assert.IsTrue(grafo.V.All(v => v.Color == GraphNodeColor.Black));
        }
    }
}
