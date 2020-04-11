using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphRepresentation
{
    public class Graph
    {
        private int Vertices;
        private int Edges;
        private List<int>[] adjList;

        public Graph(int vertices, int edges)
        {
            Vertices = vertices;
            Edges = edges;
            adjList = new List<int>[this.Vertices];

            for (int i = 0; i < this.Vertices; i++)
            {
                adjList[i] = new List<int>();
            }
        }

        public void PrintGraph()
        {
            for (int i = 0; i < Vertices; i++)
            {
                Console.Write(i + " | ");
                
                for (int j = 0; j < adjList[i].Count; j++)
                {
                    Console.Write(adjList[i][j] + " ");
                }
                
                Console.WriteLine();
             }
        }

        public void AddEdge(int u, int v)
        {
            adjList[u].Add(v);
            adjList[v].Add(u);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int v = 5;
            int e = 7;

            Graph G = new Graph(v, e);

            G.AddEdge(0, 1);
            G.AddEdge(0, 4);
            G.AddEdge(1, 2);
            G.AddEdge(1, 3);
            G.AddEdge(1, 4);
            G.AddEdge(2, 3);
            G.AddEdge(3, 4);

            G.PrintGraph();

            Console.ReadLine();
        }
    }
}
