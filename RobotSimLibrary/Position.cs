namespace RobotSimLibrary;

public enum Direction
{
    North,
    East,
    South,
    West
}

public struct Position
{
    public int X { get; set; }
    public int Y { get; set; }
    public Direction Facing { get; set; }
}