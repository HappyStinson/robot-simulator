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
        var newDir = --Facing;

        if (newDir < 0)
        {
            Facing = (Direction)_directionCount - 1;
        }
    }

    public void RotateRight()
    {
        var newDir = ++Facing;

        if ((int)newDir == _directionCount)
        {
            Facing = 0;
        }
    }

    public string GetPositionString()
    {
        return $"{X},{Y},{Facing.ToString().ToUpper()}";
    }
}