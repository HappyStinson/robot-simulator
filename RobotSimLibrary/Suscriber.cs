namespace RobotSimLibrary;

//Class that subscribes to an event
public class Subscriber
{
    public Robot? Robot { get; set; } // make private field? only public for the tests?
    private readonly (int Width, int Height) _tableDimensions = (5, 5);

    public Subscriber(RobotInstructions instructions)
    {
        // Subscribe to the command events
        instructions.RaiseCustomEvent += HandleCustomEvent;
        instructions.RaiseSimpleEvent += HandleSimpleCommand;
    }

    // Define what actions to take when the event is raised.
    void HandleCustomEvent(object sender, InstructionEventArgs e)
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

    void HandleSimpleCommand(object sender, EventArgs e)
    {
        if (Robot != null && Robot.IsPlaced)
        {
            Robot.Move();
            Console.WriteLine("Move command");
        }
    }
}