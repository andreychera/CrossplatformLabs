namespace Lab2.Test;

public class UnitTest2
{
    [Fact]
    public void ReadInput_ValidFile_ReturnsCorrectTuple()
    {
        string filePath = "testInput.txt";
        string fileContent = "9abc";
        File.WriteAllText(filePath, fileContent);

        var result = FileHandlerLab2.ReadInput(filePath);

        Assert.Equal(9, result.Item1);
        Assert.Equal("abc", result.Item2);

        // Cleanup
        File.Delete(filePath);
    }
    [Fact]
    public void ShowMatrix_ValidMatrix_DisplaysCorrectly()
    {
        int n = 4;
        int[,] matrix = new int[4, 4] 
        {
            {1, 1, 1, 1},
            {1, 1, 0, 0},
            {1, 0, 0, 0},
            {1, 0, 0, 0}
        };

        var exception = Record.Exception(() => Program.ShowMatrix(n, matrix));
        Assert.Null(exception); 
    }


    [Fact]
    public void FindLargestSquare_ValidMatrix_ReturnsCorrectResult()
    {
        int[,] matrix = new int[4, 4] 
        {
            {1, 1, 1, 1},
            {1, 1, 0, 0},
            {1, 0, 0, 0},
            {1, 0, 0, 0}
        };

        int result = Program.FindLargestSquare(4, matrix);

        Assert.Equal(2, result); 
    }

    [Fact]
    public void WriteOutput_ValidContent_WritesToFile()
    {
        var outputFilePath = "test_output.txt";
        string content = "16";

        FileHandlerLab2.WriteOutput(outputFilePath, content);

        var fileContent = File.ReadAllText(outputFilePath);
        Assert.Equal(content, fileContent);
    }
}
