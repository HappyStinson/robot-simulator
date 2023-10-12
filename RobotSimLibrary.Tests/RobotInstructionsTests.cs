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

    [Fact]
    public void ProcessInstructions_ShouldRaiseEvent()
    {
        RobotInstructions instructions = new()
        {
            Instructions = "PLACE,0,0"
        };

        instructions.Instructions = "place";
        Subscriber sub = new(instructions);

        // Call the method that raises the event.
        instructions.ProcessInstructions();

        // Assert
        // how to assert , check the robot isPlaced?

        // Keep the console window open
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }

    [Fact]
    public void ProcessInstructions_ShouldRaiseSimpleEvent()
    {
        RobotInstructions instructions = new()
        {
            Instructions = "move"
        };

        Subscriber sub = new(instructions);

        // Call the method that raises the event.
        instructions.ProcessInstructions();

        // Assert
        // how to assert , check the robot isPlaced?

        // Keep the console window open
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }
}