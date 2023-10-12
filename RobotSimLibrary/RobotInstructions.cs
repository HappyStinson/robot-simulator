using RobotSimLibrary;

enum Command
{
    Place,
    Move
};

public class RobotInstructions
{

    public string? Instructions { get; set; } // refactor to queue once file can be opened and read

    // Declare the event using EventHandler<T>
    public event EventHandler<InstructionEventArgs> RaiseCustomEvent;
    public event EventHandler<EventArgs> RaiseSimpleEvent;

    public void ProcessInstructions()
    {
        var commandtext = Instructions; // get 1 each iteration

        // Which command is it?
        var command = ParseCommand(commandtext);


        // step 1 simple logic
        switch (command)
        {
            case Command.Place:
                Console.WriteLine("Placing the Robot");
                OnRaiseCustomEvent(new InstructionEventArgs("Place triggered", GetPosition(commandtext)));
            break;
            case Command.Move:
                Console.WriteLine($"Move your body!");
                OnRaiseSimpleCommand(null);
            break;

            default:
            break;
        }

        // step 2 - discard before place

        // Write some code that does something useful here
        // then raise the event. You can also raise an event
        // before you execute a block of code.
    }

    // Wrap event invocations inside a protected virtual method
    // to allow derived classes to override the event invocation behavior
    protected virtual void OnRaiseCustomEvent(InstructionEventArgs e)
    {
        // Make a temporary copy of the event to avoid possibility of
        // a race condition if the last subscriber unsubscribes
        // immediately after the null check and before the event is raised.
        EventHandler<InstructionEventArgs> raiseEvent = RaiseCustomEvent;

        // Event will be null if there are no subscribers
        if (raiseEvent != null)
        {
            // Format the string to send inside the CustomEventArgs parameter
            e.Message += $" at {DateTime.Now}";

            // Call to raise the event.
            raiseEvent(this, e);
        }
    }

    protected virtual void OnRaiseSimpleCommand(EventArgs e)
    {
        EventHandler<EventArgs> raiseEvent = RaiseSimpleEvent;
        raiseEvent?.Invoke(this, e);
    }

    public void ReadInstructionsFromFile(string path)
    {
        Console.WriteLine(path);
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }

        // Open the file to read from.
        using (StreamReader sr = File.OpenText(path))
        {
            string? s;
            while ((s = sr.ReadLine()) != null)
            {
                Instructions = s;
                Console.WriteLine(s);
            }
        }
    }

    private Command ParseCommand(string command)
    {
        if (command == "place")
        {
            return Command.Place;
        }
        else
        {
            return Command.Move;
        }
    }

    private Position GetPosition(string position)
    {
        // parse it here
        return new Position
        {
            X = 0,
            Y = 0,
            Facing = Direction.North
        };
    }
}