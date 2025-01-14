using System;

public class Program
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

    public static void Main()
    {
        string[] input = FileHandler.ReadInput("input.txt");

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

        System.Console.WriteLine(result);

        FileHandler.WriteOutput("output.txt", result);
    }
}