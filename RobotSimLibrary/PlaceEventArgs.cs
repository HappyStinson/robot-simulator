// Define a class to hold custom event info
using RobotSimLibrary;

public class PlaceEventArgs : EventArgs
{
    public Position Position { get; set; }

    public PlaceEventArgs(Position position)
    {
        Position = position;
    }
}