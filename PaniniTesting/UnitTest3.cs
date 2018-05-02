using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaniniEngine.Graphs3;

namespace PaniniTesting
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            var node1 = new Vertex<char>() { Key = 'A' };
            var node2 = new Vertex<char>() { Key = 'B' };
            var node3 = new Vertex<char>() { Key = 'C' };
            var node4 = new Vertex<char>() { Key = 'D' };
            var node5 = new Vertex<char>() { Key = 'E' };
            var node6 = new Vertex<char>() { Key = 'F' };

            node1.Adj = new List<Vertex<char>>() { node2, node4 };
            node2.Adj = new List<Vertex<char>>() { node3, node4 };
            node3.Adj = new List<Vertex<char>>() { node1 };
            node4.Adj = new List<Vertex<char>>() { node5, node6 };
            node5.Adj = new List<Vertex<char>>();
            node6.Adj = new List<Vertex<char>>() { node2 };

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
                }
            };

            GraphManager gm = new GraphManager();
            //Graph<char> resultado = gm.Transpose(grafo);

            //Assert.IsTrue(grafo.V.Values.All(v => v.Color == VertexColor.Black));
        }
    }
}
