using System.Reflection.Metadata.Ecma335;
using RobotSimLibrary;

enum Command
{
    Place,
    Move,
    Left,
    Right,
    Report
};

public class CommandProcessor
{
    public event EventHandler<PlaceEventArgs>? RaisePlaceEvent;
    public event EventHandler<EventArgs>? RaiseMoveEvent;
    public event EventHandler? RaiseLeftEvent;
    public event EventHandler? RaiseRightEvent;
    public event EventHandler? RaiseReportEvent;

    public void ProcessCommands(string filePath)
    {
        var commands = ReadCommandsFromFile(filePath);

        foreach (string command in commands)
        {
            string[] args = command.Split(' ');

            switch (ParseCommand(args[0]))
            {
                case Command.Place:
                    var position = args[1].Split(',');
                    OnRaisePlaceEvent(new PlaceEventArgs(GetPosition(position)));
                break;
                case Command.Move:
                    OnRaiseMoveEvent(EventArgs.Empty);
                break;
                case Command.Left:
                    OnRaiseLeftEvent(EventArgs.Empty);
                break;
                case Command.Right:
                    OnRaiseRightEvent(EventArgs.Empty);
                break;
                case Command.Report:
                    OnRaiseReportEvent(EventArgs.Empty);
                break;
            }
        }

        if (commands.Length > 0)
        {
            Console.WriteLine("Parsed all commandz");
        }
    }

    public static string[] ReadCommandsFromFile(string filePath) // public for unit test
    {
        Console.WriteLine(filePath);
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException();
        }

        return File.ReadAllLines(filePath);
    }

    // Wrap event invocations inside a protected virtual method
    // to allow derived classes to override the event invocation behavior
    protected virtual void OnRaisePlaceEvent(PlaceEventArgs e)
    {
        // Make a temporary copy of the event to avoid possibility of
        // a race condition if the last subscriber unsubscribes
        // immediately after the null check and before the event is raised.
        EventHandler<PlaceEventArgs> raiseEvent = RaisePlaceEvent;
        raiseEvent?.Invoke(this, e);
    }

    protected virtual void OnRaiseMoveEvent(EventArgs e)
    {
        EventHandler<EventArgs> raiseEvent = RaiseMoveEvent;
        raiseEvent?.Invoke(this, e);
    }

    protected virtual void OnRaiseLeftEvent(EventArgs e)
    {
        EventHandler raiseEvent = RaiseLeftEvent;
        raiseEvent?.Invoke(this, e);
    }

    protected virtual void OnRaiseRightEvent(EventArgs e)
    {
        EventHandler raiseEvent = RaiseRightEvent;
        raiseEvent?.Invoke(this, e);
    }

    protected virtual void OnRaiseReportEvent(EventArgs e)
    {
        EventHandler raiseEvent = RaiseReportEvent;
        raiseEvent?.Invoke(this, e);
    }

    private static Command ParseCommand(string command)
    {
        switch (command)
        {
            case "PLACE":
                return Command.Place;
            case "MOVE":
                return Command.Move;
            case "LEFT":
                return Command.Left;
            case "RIGHT":
                return Command.Right;
            case "REPORT":
                return Command.Report;
            
            default:
                return Command.Place;
        }
    }

    private static Position GetPosition(string[] position)
    {
        return new Position
        {
            X = int.Parse(position[0]),
            Y = int.Parse(position[1]),
            Facing = GetDirection(position[2])
        };
    }

    private static Direction GetDirection(string facing)
    {
        switch (facing)
        {
            case "NORTH":
                return Direction.North;
            case "EAST":
                return Direction.East;
            case "SOUTH":
                return Direction.South;
            case "WEST":
                return Direction.West;

            default:
                return Direction.North;
        }
    }
}