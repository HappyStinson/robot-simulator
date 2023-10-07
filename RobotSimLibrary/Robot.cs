namespace RobotSimLibrary;

public class Robot
{
    public bool IsPlaced { get; private set; }
    public Position Position { get; private set; }

    public Robot()
    {
        IsPlaced = false;
        Position = new();
    }

    // Put the robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST
    public void Place(int x, int y, Direction direction)
    {
        Position = new()
        {
            X = x,
            Y = y,
            // Facing = direction
        };

        IsPlaced = true;
    }

    public void Place(Position position)
    {
        Position = position;
        IsPlaced = true;
    }

    // Move the robot one unit forward in the direction it is currently facing
    public void Move()
    {
        switch (Position.Facing)
        {
            case Direction.North:
                Position.Y++;
                break;
            case Direction.East:
                Position.X++;
                break;
            case Direction.South:
                Position.Y--;
                break;
            case Direction.West:
                Position.X--;
                break;
        }
    }

    // Rotate the robot 90 degrees left
    public void RotateLeft()
    {
        Position.RotateLeft();
    }

    // Rotate the robot 90 degrees right
    public void RotateRight()
    {
        Position.RotateRight();
    }

    // Announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient
    public string GetReportString()
    {
        if (IsPlaced)
        {
            return $"The robot is placed at {Position.X},{Position.Y} and facing {Position.Facing}.";
        }
        else
        {
            return null;
        }
    }
}
