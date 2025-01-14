using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;  // Don't forget to include the namespace for file handling

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Attempt to read the input data
            var (n, matrixLine) = FileHandlerLab2.ReadInput("INPUT.TXT");

            Console.WriteLine(matrixLine);

            // Create the matrix
            int[,] matrix = CreateMatrix(n, matrixLine);

            // Show the matrix
            ShowMatrix(n, matrix);

            // Find the largest square
            int maxk = FindLargestSquare(n, matrix);

            // Write the result to the output file
            FileHandlerLab2.WriteOutput("OUTPUT.TXT", (maxk * maxk) + "");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: File not found. {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Format error: Invalid data format in the file. {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unknown error: {ex.Message}");
        }
    }

    public static int[,] CreateMatrix(int n, string message)
    {
        try
        {
            int[,] matrix = new int[n, n];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Check to make sure we don't go out of bounds of the string
                    if (index >= message.Length)
                    {
                        throw new FormatException("Not enough data to fill the matrix.");
                    }

                    matrix[i, j] = message[index] - '0'; // Convert the character to a number
                    index++;
                }
            }
            return matrix;
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Format error while creating the matrix: {ex.Message}");
            throw;  // Re-throw the exception for further handling
        }
    }

    public static void ShowMatrix(int n, int[,] matrix)
    {
        try
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error displaying the matrix: {ex.Message}");
        }
    }

    public static int FindLargestSquare(int n, int[,] matrix)
    {
        int maxK = 0;

        try
        {
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = n - 2; j >= 0; j--)
                {
                    if (matrix[i, j] == 1)
                    {
                        int lmin = Math.Min(
                            Math.Min(matrix[i, j + 1], matrix[i + 1, j]),
                            matrix[i + 1, j + 1]
                        );
                        if (lmin > 0)
                        {
                            matrix[i, j] = lmin + 1;
                            maxK = Math.Max(maxK, matrix[i, j]);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while finding the largest square: {ex.Message}");
        }

        return maxK;
    }
}

class FileHandler
{
    public static (int, string) ReadInput(string filePath)
    {
        try
        {
            string[] input = File.ReadAllLines(filePath);
            string firstLine = input[0];

            // Check if the first line is valid
            if (string.IsNullOrEmpty(firstLine) || !int.TryParse(firstLine, out int n))
            {
                throw new FormatException("The first line must contain a number.");
            }

            string matrixLine = input.Length > 1 ? input[1] : "";
            return (n, matrixLine);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: File not found. {ex.Message}");
            throw;
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Format error: {ex.Message}");
            throw;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O error: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unknown error: {ex.Message}");
            throw;
        }
    }

    public static void WriteOutput(string filePath, string content)
    {
        try
        {
            File.WriteAllText(filePath, content);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Access error: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File writing error: {ex.Message}");
        }
    }
}