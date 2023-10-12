namespace RobotSimLibrary.Tests;

public class RobotInstructionsTests
{
    [Fact]
    public void ReadCommandsFromFile_ShouldOpenFile()
    {
        // Arrange
        CommandProcessor instructions = new();
        string? root = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.FullName;


        var assetsFolder = Path.Combine(root, "Assets");
        var file = Path.Combine(assetsFolder, "PlaceTest.txt");

        string[] expected = { "PLACE 0,0,NORTH" };

        // Act
        var actual = CommandProcessor.ReadCommandsFromFile(file);

        // Assert
        Assert.Equal(expected, actual);
    }

    // [Fact]
    // public void ProcessCommands_ShouldRaiseEvent()
    // {
    //     RobotInstructions instructions = new()
    //     {
    //         // Instructions = "PLACE,0,0"
    //     };

    //     // instructions.Instructions = "place";
    //     Subscriber sub = new(instructions);

    //     // This is the file path
    //     string? root = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.FullName;
    //     var assetsFolder = Path.Combine(root, "Assets");
    //     var filePath = Path.Combine(assetsFolder, "RobotInstructions.txt");

    //     // Call the method that raises the event.
    //     instructions.ProcessCommands(filePath);

    //     // Assert
    //     // how to assert , check the robot isPlaced?

    //     // Keep the console window open
    //     Console.WriteLine("Press any key to continue...");
    //     Console.ReadLine();
    // }

    // [Fact]
    // public void ProcessCommands_ShouldRaiseSimpleEvent()
    // {
    //     RobotInstructions instructions = new()
    //     {
    //         // Instructions = "move"
    //     };

    //     Subscriber sub = new(instructions);

    //     // This is the file path
    //     string? root = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.FullName;
    //     var assetsFolder = Path.Combine(root, "Assets");
    //     var filePath = Path.Combine(assetsFolder, "RobotInstructions.txt");

    //     // Call the method that raises the event.
    //     instructions.ProcessCommands(filePath);

    //     // Assert
    //     // how to assert , check the robot isPlaced?

    //     // Keep the console window open
    //     Console.WriteLine("Press any key to continue...");
    //     Console.ReadLine();
    // }
}