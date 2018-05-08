using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaniniEngine.Graphs3;

namespace PaniniTesting.Graphs.Vertex
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void Equals()
        {
            var node1 = new Vertex<char>() { Key = 'A' };

            var node3 = new Vertex<char>() { Key = 'C' };
            var node4 = new Vertex<char>() { Key = 'D' };
            var node5 = new Vertex<char>() { Key = 'E' };
            var node6 = new Vertex<char>() { Key = 'F' };

            //node1.Adj = new List<Vertex<char>>() { node3, node4, node5, node6 };
            node1.Adj.Add(node3);
            node1.Adj.Add(node4);
            node1.Adj.Add(node5);
            node1.Adj.Add(node6);
            var node2 = node1.Clone() as Vertex<char>;

            Assert.IsTrue(node1 == node2);
        }

    }
}
