namespace Lab3.Test;

public class UnitTest1
{public class ProgramTests
    {
        [Fact]
        public void Test_SplitStringIntoChunks()
        {
            // Arrange
            string input = "123456789";
            
            // Act
            var result = Program.SplitStringIntoChunks(input);
            
            // Assert
            Assert.Equal(new List<string> { "123", "456", "789" }, result);
        }

        [Fact]
        public void Test_SplitStringIntoChunks_WithRemainder()
        {
            // Arrange
            string input = "12345";
            
            // Act
            var result = Program.SplitStringIntoChunks(input);
            
            // Assert
            Assert.Equal(new List<string> { "123", "45" }, result);
        }

        [Fact]
        public void Test_SplitStringIntoChunks_EmptyInput()
        {
            // Arrange
            string input = "";
            
            // Act
            var result = Program.SplitStringIntoChunks(input);
            
            // Assert
            Assert.Equal(new List<string>(), result);
        }

        [Fact]
        public void Test_CreateGraph()
        {
            // Arrange
            int n = 4;
            
            // Act
            var result = Program.CreateGraph(n);
            
            // Assert
            var expectedGraph = new Dictionary<int, List<(int, int)>>
            {
                { 0, new List<(int, int)> { (3, 1), (1, 1) } },
                { 1, new List<(int, int)> { (0, 1), (2, 1) } },
                { 2, new List<(int, int)> { (1, 1), (3, 1) } },
                { 3, new List<(int, int)> { (2, 1), (0, 1) } }
            };

            Assert.Equal(expectedGraph[0], result[0]);
            Assert.Equal(expectedGraph[1], result[1]);
            Assert.Equal(expectedGraph[2], result[2]);
            Assert.Equal(expectedGraph[3], result[3]);
        }

        [Fact]
        public void Test_DijkstraAlgorithm()
        {
            // Arrange
            int n = 4;
            var graph = new Dictionary<int, List<(int, int)>>()
            {
                { 0, new List<(int, int)> { (1, 1), (3, 1) } },
                { 1, new List<(int, int)> { (0, 1), (2, 1) } },
                { 2, new List<(int, int)> { (1, 1), (3, 1) } },
                { 3, new List<(int, int)> { (2, 1), (0, 1) } }
            };

            // Act
            var result = Program.DijkstraAlgorithm(n, graph);

            // Assert
            var expected = new int[] { 0, 1, 2, 1 };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_DijkstraAlgorithm_WithIsolatedNode()
        {
            // Arrange
            int n = 4;
            var graph = new Dictionary<int, List<(int, int)>>()
            {
                { 0, new List<(int, int)> { (1, 1) } },
                { 1, new List<(int, int)> { (0, 1), (2, 1) } },
                { 2, new List<(int, int)> { (1, 1) } },
                { 3, new List<(int, int)> { } }  // Isolated node
            };

            // Act
            var result = Program.DijkstraAlgorithm(n, graph);

            // Assert
            var expected = new int[] { 0, 1, 2, int.MaxValue };
            Assert.Equal(expected, result);
        }
    }
}
