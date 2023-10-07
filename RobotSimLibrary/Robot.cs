namespace RobotSimLibrary;

public class Robot
{
    public string Text { get; set; }

    public Robot()
    {
        Text = "Robot";
    }

    public string GetReportString()
    {
        return "Hello " + Text;
    }
}
