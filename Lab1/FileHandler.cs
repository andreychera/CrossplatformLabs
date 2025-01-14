using System;
using System.IO;

public class FileHandler
{
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