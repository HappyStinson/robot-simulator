namespace RobotSimLibrary.Tests;

public class RobotInstructionsTests
{
    [Fact]
    public void ReadInstructionsFromFile_ShouldOpenFile()
    {
        // Arrange
        RobotInstructions instructions = new();
        string? root = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.FullName;
        var assetsFolder = Path.Combine(root, "Assets");
        var file = Path.Combine(assetsFolder, "RobotInstructions.txt");        

        // Act
        instructions.ReadInstructionsFromFile(file);

        // Assert
        Assert.NotNull(instructions.Instructions);
    }
}