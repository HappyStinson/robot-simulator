using RobotSimLibrary;

namespace RobotSimLibrary.Tests;

public class RobotTests
{
    [Fact]
    public void Get_SimpleStringShouldBeReported()
    {
        // Arrange
        Robot robot = new();
        string expected = "Hello Robot";

        // Act
        string actual = robot.GetReportString();

        // Assert
        Assert.Equal(expected, actual);
    }
}