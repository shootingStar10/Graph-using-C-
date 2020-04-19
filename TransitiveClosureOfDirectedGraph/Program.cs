using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitiveClosureOfDirectedGraph
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
        }

        public void PrintTrasitiveClosure()
        {
            int[][] tc = new int[Vertices][];

            for (int i = 0; i < Vertices; i++)
            {
                tc[i] = new int[Vertices];
            }

            for (int i = 0; i < Vertices; i++)
            {
                for (int j = 0; j < Vertices; j++)
                {
                    tc[i][j] = 0;
                }
            }

            for (int i = 0; i < Vertices; i++)
            {
                DFS(i, i, ref tc);
            }

            for (int i = 0; i < Vertices; i++)
            {
                for (int j = 0; j < Vertices; j++)
                {
                    Console.Write(tc[i][j]+" ");
                }

                Console.WriteLine();
            }
        }

        private void DFS(int u, int v, ref int[][] tc)
        {
            tc[u][v] = 1;

            for (int i = 0; i < adjList[v].Count; i++)
            {
                if (tc[u][adjList[v][i]] == 0)
                {
                    DFS(u, adjList[v][i], ref tc);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Graph G = new Graph(4, 5);

            G.AddEdge(0, 1);
            G.AddEdge(0, 2);
            G.AddEdge(1, 2);
            G.AddEdge(2, 0);
            G.AddEdge(2, 3);

            Console.WriteLine("Graph is: ");
            G.PrintGraph();

            Console.WriteLine("Transitive Closure matrix is: ");
            G.PrintTrasitiveClosure();

            Console.ReadLine();
        }
    }
}
