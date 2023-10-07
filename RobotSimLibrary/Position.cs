namespace RobotSimLibrary;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }
    public Direction Facing { get; set; }
    private const int _directionCount = 4;

    public void RotateLeft()
    {
        var newDir = Facing - 1;

        if (newDir < 0)
        {
            Facing = (Direction)_directionCount - 1;
        }
        else
        {
            Facing--;
        }
    }
}