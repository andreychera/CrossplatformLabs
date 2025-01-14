using System;
using System.IO;

public class FileHandlerLab3
{
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