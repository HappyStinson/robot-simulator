public class RobotInstructions
{
    public string? Instructions { get; set; } // refactor to queue once file can be opened and read
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
}