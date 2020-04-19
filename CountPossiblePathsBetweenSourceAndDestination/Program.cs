using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPossiblePathsBetweenSourceAndDestination
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

        public int CountPossiblePaths(int src, int dest)
        {
            bool[] visited = new bool[V];
            int cnt = 0;

            for (int i = 0; i < V; i++)
            {
                visited[i] = false;
            }

            solve(src, dest, visited, ref cnt);

            return cnt;
        }

        private void solve(int src, int dest, bool[] visited, ref int cnt)
        {
            if (src == dest)
            {
                cnt++;
                return;
            }

            visited[src] = true;

            for (int i = 0; i < adjList[src].Count; i++)
            {
                if (visited[adjList[src][i]] == false) 
                {
                    solve(adjList[src][i], dest, visited, ref cnt);
                }
            }

            visited[src] = false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(4, 6);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(0, 3);
            g.AddEdge(2, 0);
            g.AddEdge(2, 1);
            g.AddEdge(1, 3);

            Console.WriteLine("Graph is: ");
            g.PrintGraph();

            int s = 2, d = 3;
            Console.WriteLine($"Source vertex = {s} and Destination vertex = {d}");

            int pathCount = g.CountPossiblePaths(s, d);
            Console.WriteLine($"Count of possible paths between source and destination is = {pathCount}");

            Console.ReadLine();
        }
    }
}
