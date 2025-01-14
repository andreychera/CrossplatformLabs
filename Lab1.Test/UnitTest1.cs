namespace Lab1.Test;
using Lab1;

public class UnitTest1
{
    public class FileHandlerTests
    {
        [Fact]
        public void ReadInput_ShouldReturnCorrectData()
        {
            // Arrange
            string filePath = "test_input.txt";
            string[] expected = { "5", "3", "2", "1" };

            // Write a temporary file
            File.WriteAllLines(filePath, new string[] { "5 3 2 1" });

            // Act
            string[] result = FileHandler.ReadInput(filePath);

            // Assert
            Assert.Equal(expected, result);

            // Cleanup
            File.Delete(filePath);
        }

        [Fact]
        public void WriteOutput_ShouldWriteCorrectData()
        {
            // Arrange
            string filePath = "test_output.txt";
            string output = "YES\n1 1 1 1 1 1";

            // Act
            FileHandler.WriteOutput(filePath, output);

            // Assert
            string result = File.ReadAllText(filePath);
            Assert.Equal(output, result);

            // Cleanup
            File.Delete(filePath);
        }
    }

    public class ProgramTests
    {
        [Theory]
        [InlineData(5, 3, 2, 1, "YES\n1 2 0 2 0 0")]
        [InlineData(10, 3, 3, 3, "NO")]
        public void FindSolution_ShouldReturnExpectedResult(int n, int nAB, int nBC, int nAC, string expected)
        {
            // Act
            string result = Program.FindSolution(n, nAB, nBC, nAC);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}