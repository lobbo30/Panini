﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaniniEngine.Graphs;

namespace PaniniTesting
{
    [TestClass]
    public class TopologicalSortTests
    {
        [TestMethod]
        public void TopologicalSort()
        {
            var node1 = new Vertex<char>() { Key = 'A' };
            var node2 = new Vertex<char>() { Key = 'B' };
            var node3 = new Vertex<char>() { Key = 'C' };
            var node4 = new Vertex<char>() { Key = 'D' };
            var node5 = new Vertex<char>() { Key = 'E' };
            var node6 = new Vertex<char>() { Key = 'F' };

            Graph<char> grafo = new Graph<char>()
            {
                V = new Dictionary<char, Vertex<char>>()
                {
                    { node1.Key, node1 },
                    { node2.Key, node2 },
                    { node3.Key, node3 },
                    { node4.Key, node4 },
                    { node5.Key, node5 },
                    { node6.Key, node6 }
                },
                Adj = new Dictionary<Vertex<char>, List<Vertex<char>>>()
                {
                    { node1, new List<Vertex<char>>() { node2, node4 } },
                    { node2, new List<Vertex<char>>() { node3, node4 } },
                    { node3, new List<Vertex<char>>() { node1 } },
                    { node4, new List<Vertex<char>>() { node5, node6 } },
                    { node5, new List<Vertex<char>>() },
                    { node6, new List<Vertex<char>>() { node2 } }
                }
            };

            GraphManager gm = new GraphManager();
            var resultado = gm.TopologicalSort(grafo);

            Assert.AreEqual('A', resultado[0].Key);
            Assert.AreEqual('B', resultado[1].Key);
            Assert.AreEqual('D', resultado[2].Key);
            Assert.AreEqual('F', resultado[3].Key);
            Assert.AreEqual('E', resultado[4].Key);
            Assert.AreEqual('C', resultado[5].Key);
        }
    }
}
