namespace RobotSimLibrary;

public class Subscriber
{
    public Robot? Robot { get; set; }
    public readonly (int Width, int Height) TableDimensions = (5, 5);

    public Subscriber(CommandProcessor commands)
    {
        // Subscribe to the command events
        commands.RaisePlaceEvent += HandlePlaceEvent;
        commands.RaiseMoveEvent += HandleMoveEvent;
        commands.RaiseLeftEvent += HandleLeftEvent;
        commands.RaiseRightEvent += HandleRightEvent;
        commands.RaiseReportEvent += HandleReportEvent;
    }

    public void HandlePlaceEvent(object sender, PlaceEventArgs e)
    {
        if (IsValidPosition(e.Position))
        {
            PlaceRobot(e.Position);
        }
    }
    
    private bool IsValidPosition(Position pos)
    {
        // Check if the placement is valid and within the table boundaries.
        return ((pos.X >= 0 && pos.X < TableDimensions.Width) && (pos.Y >= 0 && pos.Y < TableDimensions.Height));
    }

    private void PlaceRobot(Position pos)
    {
        Robot ??= new();        
        Robot.Place(pos);
    }

    public void HandleMoveEvent(object sender, EventArgs e)
    {
        if (Robot != null && Robot.IsPlaced)
        {
            Robot.Move(TableDimensions.Width - 1, TableDimensions.Height - 1);
        }
    }

    private void HandleLeftEvent(object sender, EventArgs e)
    {
        if (Robot != null && Robot.IsPlaced)
        {
            Robot.RotateLeft();
        }
    }

    private void HandleRightEvent(object sender, EventArgs e)
    {
        if (Robot != null && Robot.IsPlaced)
        {
            Robot.RotateRight();
        }
    }

    private void HandleReportEvent(object sender, EventArgs e)
    {
        if (Robot != null && Robot.IsPlaced)
        {
            // Announce the X,Y and F of the robot.
            Console.WriteLine(Robot.GetPositionString());
        }
    }
}