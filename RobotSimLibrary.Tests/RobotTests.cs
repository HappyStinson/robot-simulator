using System.Text;
using RobotSimLibrary;

namespace RobotSimLibrary.Tests;

public class RobotTests
{
    // [Theory]
    // [InlineData(0, 0, Direction.North)]
    // public void Place_RobotShouldBePlaced(int x, int y, Direction facing)
    // {
    //     // Arrange
    //     Robot robot = new();
    //     Position expected = new()
    //     {
    //         X = x,
    //         Y = y,
    //         Facing = facing
    //     };

    //     // Act
    //     robot.Place(x, y, facing);

    //     // Assert
    //     Assert.Equal(expected, robot.Position);
    //     Assert.True(robot.IsPlaced);
    // }

    // [Theory]
    // [InlineData({ X = 0, Y = 0,   })]
    // public void Place_RobotShouldBePlaced(Position position)
    // {
    //     // Arrange
    //     Robot robot = new();
    //     Position expected = new()
    //     {
    //         X = x,
    //         Y = y,
    //         Facing = facing
    //     };

    //     // Act
    //     robot.Place(x, y, facing);

    //     // Assert
    //     Assert.Equal(expected, robot.Position);
    //     Assert.True(robot.IsPlaced);
    // }

    [Theory]
    [InlineData(Direction.North, Direction.West)]
    [InlineData(Direction.East, Direction.North)]
    [InlineData(Direction.South, Direction.East)]
    [InlineData(Direction.West, Direction.South)]
    public void RotateLeft_ShouldUpdateDirection(Direction before, Direction after)
    {
        // Arrange
        Direction expected = after;

        Robot robot = new();
        Position pos = new() { X = 0, Y = 0, Facing = before };
        robot.Place(pos);

        // Act
        robot.RotateLeft();
        var actual = robot.Position.Facing;

        // Assert
        Assert.Equal(expected, actual);        
    }

    [Fact]
    public void GetReportString_PlacedRobotPositionShouldBeReported()
    {
        // Arrange
        Robot robot = new();
        Position pos = new() { X = 1, Y = 2, Facing = Direction.West };
        robot.Place(pos);
        string expected = "The robot is placed at 1,2 and facing West.";

        // Act
        string actual = robot.GetReportString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetReportString_NotPlacedRobotShouldNotBeReported()
    {
        // Arrange
        Robot robot = new();
        string expected = null;

        // Act
        string actual = robot.GetReportString();

        // Assert
        Assert.Equal(expected, actual);
    }
}