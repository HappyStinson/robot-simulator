// Define a class to hold custom event info
using RobotSimLibrary;

public class InstructionEventArgs : EventArgs // Place Event ?
{
    public InstructionEventArgs(string message, Position position)
    {
        Message = message;
        Position = position;
    }

    public string Message { get; set; }
    public Position Position { get; set; }
}