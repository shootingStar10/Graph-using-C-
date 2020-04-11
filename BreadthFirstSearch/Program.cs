using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    public class Graph
    {
        private int Vertices;
        private int Edges;
        private List<int>[] adjList;

        public Graph(int v, int e)
        {
            Vertices = v;
            Edges = e;
            adjList = new List<int>[v];

            for (int i = 0; i < Vertices; i++)
            {
                adjList[i] = new List<int>();
            }
        }

        public void AddEdge(int u, int v)
        {
            adjList[u].Add(v);
            adjList[v].Add(u);
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

        public void PrintBFS(int start)
        {
            Queue<int> q = new Queue<int>();
            bool[] visited = new bool[Vertices];

            for (int i = 0; i < Vertices; i++)
            {
                visited[i] = false;
            }

            q.Enqueue(start);
            visited[start] = true;

            while (q.Count > 0)
            {
                int i = q.Peek();
                Console.Write(i + " ");
                q.Dequeue();

                for (int j = 0; j < adjList[i].Count; j++)
                {
                    if (visited[adjList[i][j]] == false)
                    {
                        q.Enqueue(adjList[i][j]);
                        visited[adjList[i][j]] = true;
                    }
                }
            }

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph G = new Graph(6, 8);

            G.AddEdge(0, 1);
            G.AddEdge(0, 2);
            G.AddEdge(1, 3);
            G.AddEdge(1, 4);
            G.AddEdge(2, 4);
            G.AddEdge(3, 4);
            G.AddEdge(3, 5);
            G.AddEdge(4, 5);

            Console.WriteLine("Graph is: ");
            G.PrintGraph();

            Console.WriteLine("BFS is: ");
            G.PrintBFS(0);

            Console.ReadLine();
        }
    }
}
