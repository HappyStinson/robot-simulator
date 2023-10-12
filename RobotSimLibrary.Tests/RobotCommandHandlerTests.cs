namespace RobotSimLibrary.Tests;

public class RobotCommandHandlerTests
{
    [Fact]
    public void HandlePlaceEvent_ValidPositionShouldWork()
    {
        // Arrange
        CommandProcessor processor = new();
        RobotCommandHandler handler = new(processor);
        Position expected = new()
        {
            X = 1,
            Y = 2,
            Facing = Direction.East
        };

        // Act
        handler.HandlePlaceEvent(this, new PlaceEventArgs(expected));
        var actual = handler.Robot?.Position;
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void HandlePlaceEvent_InvalidPositionShouldBeIgnored()
    {
        // Arrange
        CommandProcessor processor = new();
        RobotCommandHandler handler = new(processor);
        Position invalid = new()
        {
            X = handler.TableDimensions.Width + 1,
            Y = 2,
            Facing = Direction.East
        };

        // Act
        handler.HandlePlaceEvent(this, new PlaceEventArgs(invalid));
        
        // Assert
        Assert.Null(handler.Robot?.Position);
    }

    [Fact]
    public void HandleMoveEvent_ValidMoveShouldWork()
    {
        // Arrange
        CommandProcessor processor = new();
        RobotCommandHandler handler = new(processor);
        Position start = new() { X = 1, Y = 2, Facing = Direction.North };
        var expected = start.Y + 1;

        // Act
        handler.HandlePlaceEvent(this, new PlaceEventArgs(start));
        handler.HandleMoveEvent(this, EventArgs.Empty);
        var actual = handler.Robot?.Position?.Y;
        
        // Assert
        Assert.Equal(expected, actual);
    }
}