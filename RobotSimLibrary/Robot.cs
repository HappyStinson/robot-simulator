namespace RobotSimLibrary;

public class Robot
{
    public bool IsPlaced { get; private set; }
    public Position? Position { get; private set; }

    public Robot()
    {
        IsPlaced = false;
    }

    // Put the robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST
    public void Place(Position position)
    {
        Position = position;
        IsPlaced = true;
    }

    // Move the robot one unit forward in the direction it is currently facing
    public void Move(int width, int height)
    {
        switch (Position?.Facing)
        {
            case Direction.North:
                if (Position.Y + 1 <= height)
                {
                    Position.Y++;
                }
                break;
            case Direction.East:
                if (Position.X + 1 <= width)
                {
                    Position.X++;
                }
                break;
            case Direction.South:
                if (Position.Y - 1 > -1)
                {
                    Position.Y--;
                }
                break;
            case Direction.West:
                if (Position.X - 1 > -1)
                {
                    Position.X--;
                }
                break;
        }
    }

    // Rotate the robot 90 degrees left
    public void RotateLeft()
    {
        Position?.RotateLeft();
    }

    // Rotate the robot 90 degrees right
    public void RotateRight()
    {
        Position?.RotateRight();
    }

    // Announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient
    public string? GetPositionString()
    {
        return Position?.GetPositionString();
    }
}
