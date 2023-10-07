using RobotSimLibrary;

namespace RobotSimLibrary.Tests;

public class RobotTests
{
    [Fact]
    public void Place_PositionShouldBeUpdated()
    {
        
    }

    [Fact] // change to theory?
    public void GetReportString_PositionShouldBeReported()
    {
        // Arrange
        Robot robot = new();
        string expected = "The robot is placed at 0,0 and facing North.";

        // Act
        string actual = robot.GetReportString();

        // Assert
        Assert.Equal(expected, actual);
    }
}