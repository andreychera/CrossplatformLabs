using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabLibrary
{
    public class Lab1
    {
        public static string FindSolution(int n, int nAB, int nBC, int nAC)
        {
            string result = "NO";  

            for (int kA = 0; kA <= nAB && kA <= nAC; kA++)
            {
                for (int kB = 0; kB <= nAB && kB <= nBC; kB++)
                {
                    for (int kC = 0; kC <= nBC && kC <= nAC; kC++)
                    {
                        int kAB = nAB - kA - kB;
                        int kBC = nBC - kB - kC;
                        int kAC = nAC - kA - kC;

                        if (kAB >= 0 && kBC >= 0 && kAC >= 0 &&
                            kA + kAB + kB + kBC + kC + kAC == n)
                        {
                            result = $"YES\n{kA} {kAB} {kB} {kBC} {kC} {kAC}";
                            break;
                        }
                    }
                    if (result == "YES") break;
                }
                if (result == "YES") break;
            }

            return result;
        }

        public static void Execute()
        {
            string[] input = ReadInput("INPUT.TXT");

            if (input.Length == 0)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            int n = int.Parse(input[0]);
            int nAB = int.Parse(input[1]);
            int nBC = int.Parse(input[2]);
            int nAC = int.Parse(input[3]);

            string result = FindSolution(n, nAB, nBC, nAC);

            WriteOutput("OUTPUT.TXT", result);
        }

        public static string[] ReadInput(string filePath)
        {
        try
        {
            string[] input = File.ReadAllLines(filePath);
            return input[0].Split();  
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            return new string[0];
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