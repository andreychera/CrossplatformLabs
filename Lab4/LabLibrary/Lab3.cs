using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace LabLibrary
{
    public class Lab3
    {
        public static void Execute()
        {
            try
            {
                var (n, Line) = ReadInput("INPUT.TXT");
                var windows = ReadWindowsData(n, Line);
                var graph = CreateGraph(n);
                var dist = DijkstraAlgorithm(n, graph);

                string result = "";
                StringBuilder sb = new StringBuilder(result);
                foreach (var d in dist)
                {
                    sb.Append(d + " ");
                }

                result = sb.ToString();

                WriteOutput("OUTPUT.TXT", result);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: File not found. {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: Invalid data format. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        public static List<string> SplitStringIntoChunks(string input)
        {
            try
            {
                List<string> chunks = new List<string>();

                for (int i = 0; i < input.Length; i += 3)
                {
                    string chunk = input.Substring(i, Math.Min(3, input.Length - i));
                    chunks.Add(chunk);
                }

                return chunks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SplitStringIntoChunks: {ex.Message}");
                return new List<string>(); // Return empty list if error occurs
            }
        }

        public static List<(int app, int index)> ReadWindowsData(int n, string line)
        {
            try
            {
                List<string> chunks = SplitStringIntoChunks(line);
                var windows = new List<(int app, int index)>(n);
                for (int i = 0; i < n; i++)
                {
                    var parts = chunks[i].Split(" ");
                    int app = int.Parse(parts[0]);
                    int index = int.Parse(parts[1]);
                    windows.Add((app, index));
                }
                return windows;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Error: Data is missing or invalid in the line. {ex.Message}");
                return new List<(int app, int index)>();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: Failed to parse numbers from the line. {ex.Message}");
                return new List<(int app, int index)>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error in ReadWindowsData: {ex.Message}");
                return new List<(int app, int index)>();
            }
        }

        public static Dictionary<int, List<(int, int)>> CreateGraph(int n)
        {
            try
            {
                var graph = new Dictionary<int, List<(int, int)>>();
                for (int i = 0; i < n; i++)
                {
                    if (!graph.ContainsKey(i)) graph[i] = new List<(int, int)>();
                    int prev = (i - 1 + n) % n;
                    int next = (i + 1) % n;
                    graph[i].Add((prev, 1));
                    graph[i].Add((next, 1));
                }
                return graph;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateGraph: {ex.Message}");
                return new Dictionary<int, List<(int, int)>>(); // Return an empty graph if error occurs
            }
        }

        public static int[] DijkstraAlgorithm(int n, Dictionary<int, List<(int, int)>> graph)
        {
            try
            {
                var dist = new int[n];
                var pq = new SortedSet<(int dist, int node)>();
                for (int i = 0; i < n; i++) dist[i] = int.MaxValue;
                dist[0] = 0;
                pq.Add((0, 0));

                while (pq.Count > 0)
                {
                    var (d, u) = pq.Min;
                    pq.Remove(pq.Min);

                    foreach (var (v, weight) in graph[u])
                    {
                        int alt = d + weight;
                        if (alt < dist[v])
                        {
                            pq.Remove((dist[v], v));
                            dist[v] = alt;
                            pq.Add((dist[v], v));
                        }
                    }
                }
                return dist;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DijkstraAlgorithm: {ex.Message}");
                return new int[n]; 
            }
        }

            public static (int, string) ReadInput(string filePath)
        {
            try
            {
                string[] input = File.ReadAllLines(filePath);
                string firstPart = input[0]; 
                int firstNumber = int.Parse(firstPart.Substring(0, 1)); 
                string remainingPart = firstPart.Substring(1); 

                return (firstNumber, remainingPart); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return (0, ""); 
            }
        }

        public static void WriteOutput(string filePath, string output)
        {
            try
            {
                File.WriteAllText(filePath, output);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
    }
}