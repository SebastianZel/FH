using System;

using AlgoDat;

namespace code_alg_tiefensuche
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new();

            graph.AddEdge("start", "A");
            graph.AddEdge("start", "b");
            graph.AddEdge("A", "c"); graph.AddEdge("c", "A");
            graph.AddEdge("A", "b"); graph.AddEdge("b", "A");
            graph.AddEdge("b", "d");
            graph.AddEdge("A", "end"); 
            graph.AddEdge("b", "end"); 
            

            DepthFirstSearch<string>.TraversIterative(graph, "start", DoWithNode);

            Console.WriteLine("Recursive");
            DepthFirstSearch<string>.Travers(graph, "start", DoWithNodeRecursive);
        }

        static void DoWithNode(string node)
        {
            Console.WriteLine($"Process node {node}");
        }

        static void DoWithNodeRecursive(string node)
        {
            Console.WriteLine($"Process recursive node {node}");
        }
    }
}
