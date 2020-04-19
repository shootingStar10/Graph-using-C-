using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectCycleInDirectedGraph
{
    public class Graph
    {
        private int V, E;
        private List<int>[] adjList;

        public Graph(int v, int e)
        {
            V = v;
            E = e;
            adjList = new List<int>[V];

            for (int i = 0; i < V; i++)
            {
                adjList[i] = new List<int>();
            }
        }

        public void AddEdge(int u, int v)
        {
            adjList[u].Add(v);
        }

        public void PrintGraph()
        {
            for (int i = 0; i < V; i++)
            {
                Console.Write(i + "| ");
                for (int j = 0; j < adjList[i].Count; j++)
                {
                    Console.Write(adjList[i][j] + " ");
                }

                Console.WriteLine();
            }
        }

        public bool HasCycle()
        {
            bool[] visited = new bool[V];
            bool[] recStack = new bool[V];

            for (int i = 0; i < V; i++)
            {
                visited[i] = false;
                recStack[i] = false;
            }

            for (int i = 0; i < V; i++)
            {
                if (DFS(i, visited, recStack) == true)
                {
                    return true;
                }
            }

            return false;
        }

        private bool DFS(int i, bool[] visited, bool[] recStack)
        {
            visited[i] = true;
            recStack[i] = true;

            for (int j = 0; j < adjList[i].Count; j++)
            {
                if (visited[adjList[i][j]] == false && DFS(adjList[i][j], visited, recStack) == true)
                {
                    return true;
                }
                else if (recStack[adjList[i][j]] == true)
                {
                    return true;
                }
            }

            recStack[i] = false;

            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(4, 6);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("Graph is: ");
            g.PrintGraph();

            if (g.HasCycle() == true)
            {
                Console.WriteLine("Graph has cycle.");
            }
            else
            {
                Console.WriteLine("Graph has not cycle.");
            }

            Console.ReadLine();
        }
    }
}
