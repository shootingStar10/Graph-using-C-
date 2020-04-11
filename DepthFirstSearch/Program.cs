using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch
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

        // Directed graph
        public void AddEdge(int u, int v)
        {
            adjList[u].Add(v);
            //adjList[v].Add(u);
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

        public void PrintDFS(int start)
        {
            Stack<int> s = new Stack<int>();
            bool[] visited = new bool[Vertices];

            for (int i = 0; i < Vertices; i++)
            {
                visited[i] = false;
            }

            s.Push(start);
            visited[start] = true;

            while (s.Count > 0)
            {
                int i = s.Peek();
                Console.Write(i + " ");
                s.Pop();

                for (int j = 0; j < adjList[i].Count; j++)
                {
                    if (visited[adjList[i][j]] == false)
                    {
                        s.Push(adjList[i][j]);
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
            Graph G = new Graph(5, 5);

            G.AddEdge(1, 0);
            G.AddEdge(0, 2);
            G.AddEdge(2, 1);
            G.AddEdge(0, 3);
            G.AddEdge(1, 4);

            Console.WriteLine("Graph is: ");
            G.PrintGraph();

            Console.WriteLine("DFS is: ");
            G.PrintDFS(0);

            Console.ReadLine();
        }
    }
}
