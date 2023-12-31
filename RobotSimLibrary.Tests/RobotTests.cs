namespace RobotSimLibrary.Tests;

public class RobotTests
{
    [Fact]
    public void Place_RobotShouldBePlaced()
    {
        // Arrange
        Robot robot = new();
        Position expected = new() { X = 3, Y = 2, Facing = Direction.South };

        // Act
        robot.Place(expected);

        // Assert
        Assert.Equal(expected, robot.Position);
        Assert.True(robot.IsPlaced);
    }

    [Theory]
    [InlineData(0, 0, 0, 1, Direction.North)]
    [InlineData(1, 1, 1, 0, Direction.East)]
    [InlineData(2, 3, 0, -1, Direction.South)]
    [InlineData(3, 3, -1, 0, Direction.West)]
    public void Move_ShouldUpdatePosition(int x, int y, int addX, int addY, Direction facing)
    {
        // Arrange
        Robot robot = new();
        Position start = new() { X = x, Y = y, Facing = facing};
        robot.Place(start);
        var tableBoundary = 4;

        var expected = (robot.Position?.X + addX, robot.Position?.Y + addY);

        // Act
        robot.Move(tableBoundary, tableBoundary);

        // Assert
        var actual = (robot.Position?.X, robot.Position?.Y);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 4, Direction.North)]
    [InlineData(4, 1, Direction.East)]
    [InlineData(2, 0, Direction.South)]
    [InlineData(0, 3, Direction.West)]
    public void Move_InvalidPositionShouldBeIgnored(int x, int y, Direction facing)
    {
        // Arrange
        Robot robot = new();
        Position start = new() { X = x, Y = y, Facing = facing};
        var expected = (x, y);
        robot.Place(start);
        var tableBoundary = 4;

        // Act
        robot.Move(tableBoundary, tableBoundary);

        // Assert
        var actual = (robot.Position?.X, robot.Position?.Y);
        Assert.Equal(expected, actual);
    }

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
        var actual = robot.Position?.Facing;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Direction.North, Direction.East)]
    [InlineData(Direction.East, Direction.South)]
    [InlineData(Direction.South, Direction.West)]
    [InlineData(Direction.West, Direction.North)]
    public void RotateRight_ShouldUpdateDirection(Direction before, Direction after)
    {
        // Arrange
        Direction expected = after;

        Robot robot = new();
        Position pos = new() { X = 0, Y = 0, Facing = before };
        robot.Place(pos);

        // Act
        robot.RotateRight();
        var actual = robot.Position?.Facing;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetPositionString_PlacedRobotPositionShouldBeReported()
    {
        // Arrange
        Robot robot = new();
        Position pos = new() { X = 1, Y = 2, Facing = Direction.West };
        robot.Place(pos);
        string expected = "1,2,WEST";

        // Act
        string? actual = robot.GetPositionString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetPositionString_NotPlacedRobotShouldNotBeReported()
    {
        // Arrange
        Robot robot = new();

        // Act
        string? actual = robot.GetPositionString();

        // Assert
        Assert.Null(actual);
    }
}