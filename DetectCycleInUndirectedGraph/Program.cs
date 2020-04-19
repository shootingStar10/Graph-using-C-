using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectCycleInUndirectedGraph
{
    class Program
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
                adjList[v].Add(u);
            }

            public void PrintGraph()
            {
                for (int i = 0; i < V; i++)
                {
                    Console.Write(i + " | ");

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

                for (int i = 0; i < V; i++)
                {
                    visited[i] = false;
                }

                for (int i = 0; i < V; i++)
                {
                    if (visited[i] == false && DFS(i, visited, -1) == true)
                    {
                        return true;
                    }
                }

                return false;
            }

            private bool DFS(int i, bool[] visited, int parent)
            {
                visited[i] = true;

                for (int j = 0; j < adjList[i].Count; j++)
                {
                    if (visited[adjList[i][j]] == false)
                    {
                        if (DFS(adjList[i][j], visited, i) == true)
                        {
                            return true;
                        }
                    }
                    else if (adjList[i][j] != parent)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        static void Main(string[] args)
        {
            Graph g1 = new Graph(5, 5);

            g1.AddEdge(0, 1);
            //g1.AddEdge(0, 2);
            g1.AddEdge(0, 3);
            g1.AddEdge(1, 2);
            g1.AddEdge(3, 4);

            Console.WriteLine("Graph is: ");
            g1.PrintGraph();

            if (g1.HasCycle() == true)
            {
                Console.WriteLine("Graph contains cycle.");
            }
            else
            {
                Console.WriteLine("Graph does not contain cycle.");
            }

            Console.ReadLine();
        }
    }
}
