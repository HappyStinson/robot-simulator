namespace RobotSimLibrary;

public class Robot
{
    public bool HasBeenPlaced { get; set; } // updated by board who knows the dimensions
    public Position Position { get; set; } // private set?

    public Robot()
    {
        HasBeenPlaced = false;
    }

    public void Place(int x, int y, Direction direction)
    {
        Position = new()
        {
            X = x,
            Y = y,
            Facing = direction
        };
    }

    public string GetReportString()
    {
        // Announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient
        // Check cast of Direction...
        return $"The robot is placed at {Position.X},{Position.Y} and facing {Position.Facing}.";
    }
}
