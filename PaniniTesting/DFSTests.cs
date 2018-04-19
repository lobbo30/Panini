using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaniniEngine.Graphs;

namespace PaniniTesting
{
    [TestClass]
    public class DFSTests
    {
        [TestMethod]
        public void DFS()
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
            gm.DFS(grafo);

            Assert.IsTrue(grafo.V.All(v => v.Color == GraphNodeColor.Black));
        }
    }
}
