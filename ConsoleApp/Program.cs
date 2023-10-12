using RobotSimLibrary;

string? root = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
var assetsFolder = Path.Combine(root, "Assets");
var filePath = Path.Combine(assetsFolder, "RobotInstructions.txt");

CommandProcessor processor = new();
Subscriber sub = new(processor);

try
{
    processor.ProcessCommands(filePath);
}
catch (FileNotFoundException)
{   
    Console.WriteLine($"Can't find your file bro. {filePath}");
}