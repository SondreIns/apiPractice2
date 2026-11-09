namespace ConsoleHelper;

public static class ConsoleWriter
{
    public static void WriteLine(string message, ConsoleColor colour)
    {
        ConsoleColor col = Console.ForegroundColor;
        Console.ForegroundColor = colour;
        Console.WriteLine(message);
        Console.ForegroundColor = col;
    }

    public static void Write(string message, ConsoleColor colour)
    {
        ConsoleColor col = Console.ForegroundColor;
        Console.ForegroundColor = colour;
        Console.Write(message);
        Console.ForegroundColor = col;
    }
}