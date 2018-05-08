using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaniniEngine.Graphs3;

namespace PaniniTesting
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void Transpose()
        {
            var node1 = new Vertex<char>() { Key = 'A' };
            var node2 = new Vertex<char>() { Key = 'B' };
            var node3 = new Vertex<char>() { Key = 'C' };
            var node4 = new Vertex<char>() { Key = 'D' };
            var node5 = new Vertex<char>() { Key = 'E' };
            var node6 = new Vertex<char>() { Key = 'F' };

            node1.Adj.Add(node2);
            node1.Adj.Add(node4);

            node2.Adj.Add(node3);
            node2.Adj.Add(node4);

            //node3.Adj.Add(node1); // Esto produce la aparición de un ciclo.

            node4.Adj.Add(node5);
            node4.Adj.Add(node6);

            //node6.Adj.Add(node2);

            Graph<char> grafo = new Graph<char>();
            grafo.V.Add(node1.Key, node1);
            grafo.V.Add(node2.Key, node2);
            grafo.V.Add(node3.Key, node3);
            grafo.V.Add(node4.Key, node4);
            grafo.V.Add(node5.Key, node5);
            grafo.V.Add(node6.Key, node6);

            // Transposed graph

            var node11 = new Vertex<char>() { Key = 'A' };
            var node12 = new Vertex<char>() { Key = 'B' };
            var node13 = new Vertex<char>() { Key = 'C' };
            var node14 = new Vertex<char>() { Key = 'D' };
            var node15 = new Vertex<char>() { Key = 'E' };
            var node16 = new Vertex<char>() { Key = 'F' };

            node12.Adj.Add(node11);

            node13.Adj.Add(node12);

            node14.Adj.Add(node11);
            node14.Adj.Add(node12);

            node15.Adj.Add(node14);

            node16.Adj.Add(node14);

            Graph<char> transposedGraph = new Graph<char>();
            transposedGraph.V.Add(node11.Key, node11);
            transposedGraph.V.Add(node12.Key, node12);
            transposedGraph.V.Add(node13.Key, node13);
            transposedGraph.V.Add(node14.Key, node14);
            transposedGraph.V.Add(node15.Key, node15);
            transposedGraph.V.Add(node16.Key, node16);

            GraphManager gm = new GraphManager();
            Graph<char> resultado = gm.Transpose(grafo);

            Assert.IsTrue(resultado == transposedGraph);
        }
    }
}
