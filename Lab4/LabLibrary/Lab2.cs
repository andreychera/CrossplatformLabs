using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;    


namespace LabLibrary
{
    public class Lab2
    {    
        public static void Execute()
        {
            try
            {
                var (n, matrixLine) = ReadInput("INPUT.TXT");

                Console.WriteLine(matrixLine);

                int[,] matrix = CreateMatrix(n, matrixLine);

                ShowMatrix(n, matrix);

                int maxk = FindLargestSquare(n, matrix);

                WriteOutput("OUTPUT.TXT", (maxk * maxk) + "");
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
                        if (index >= message.Length)
                        {
                            throw new FormatException("Not enough data to fill the matrix.");
                        }

                        matrix[i, j] = message[index] - '0';
                        index++;
                    }
                }
                return matrix;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format error while creating the matrix: {ex.Message}");
                throw;  
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
}