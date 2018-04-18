using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaniniEngine.Graphs
{
    public class GraphNode
    {
        public bool Visited { get; set; }
        public int Cabeza { get; set; }
    }

    public class Graph
    {
        public List<GraphNode> Nodos { get; set; }
    }

    public class GraphManager
    {
        public bool CycleDetect(Graph grafo, int actual, int fijo)
        {
            //bool ciclo = true;
            //GraphNode vecino = null;
            // lista de algo

            bool ciclo = false;
            grafo.Nodos[actual].Visited = true;
            var ptrNodo = grafo.Nodos[actual].Cabeza;
            while (ptrNodo != -1 && !ciclo)
            {
                int vecino = ptrNodo;
                if (!grafo.Nodos[vecino].Visited)
                {
                    ciclo = CycleDetect(grafo, vecino, fijo);
                }
                else
                {
                    if (vecino == fijo)
                    {
                        ciclo = true;
                    }
                }
                ptrNodo++;
            }
            return ciclo;
        }
    }
}
