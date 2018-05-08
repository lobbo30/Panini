using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaniniEngine.Graphs3;

namespace PaniniTesting
{
    [TestClass]
    public class GraphEqualsTests
    {
        [TestMethod]
        public void Equals()
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

            Graph<char> grafo2 = grafo.Clone() as Graph<char>;

            Assert.IsTrue(grafo == grafo2); // falta considerar cuando el grafo tiene ciclos.
        }
    }
}
