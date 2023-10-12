namespace RobotSimLibrary;

//Class that subscribes to an event
public class Subscriber
{
    public Robot? Robot { get; set; } // make private field? only public for the tests?
    private readonly (int Width, int Height) _tableDimensions = (5, 5);

    public Subscriber(CommandProcessor commands)
    {
        // Subscribe to the command events
        commands.RaisePlaceEvent += HandlePlaceEvent;
        commands.RaiseMoveEvent += HandleMoveEvent;
        commands.RaiseLeftEvent += HandleLeftEvent;
        commands.RaiseRightEvent += HandleRightEvent;
        commands.RaiseReportEvent += HandleReportEvent;
    }

    // Define what actions to take when the event is raised.
    void HandlePlaceEvent(object sender, PlaceEventArgs e)
    {
        if (IsValidPosition(e.Position))
        {
            PlaceRobot(e.Position);
        }
    }

    private bool IsValidPosition(Position pos)
    {
        // Check if the placement is valid and within the table boundaries.
        return ((pos.X >= 0 && pos.X < _tableDimensions.Width) && (pos.Y >= 0 && pos.Y < _tableDimensions.Height));
    }

    private void PlaceRobot(Position pos)
    {
        Robot ??= new();        
        Robot.Place(pos);
    }

    void HandleMoveEvent(object sender, EventArgs e)
    {
        if (Robot != null && Robot.IsPlaced)
        {
            Robot.Move();
            Console.WriteLine("Move command");
        }
    }

    private void HandleLeftEvent(object sender, EventArgs e)
    {
        if (Robot != null && Robot.IsPlaced)
        {
            Robot.RotateLeft();
            Console.WriteLine("LEFT command");
        }
    }

    private void HandleRightEvent(object sender, EventArgs e)
    {
        if (Robot != null && Robot.IsPlaced)
        {
            Robot.RotateRight();
            Console.WriteLine("RIGHT command");
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