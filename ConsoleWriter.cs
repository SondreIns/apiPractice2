namespace ConsoleHelper;

// Hjelpeklasse som tar farge som argument, og sett deretter fargen tilbake til orignal.
public static class ConsoleWriter
{
    /// <summary>
    /// Console.WriteLine with colour input, sets colour back to original after calling
    /// </summary>
    /// <param name="message">Message to display</param>
    /// <param name="colour">ConsoleColour for text</param>
    public static void WriteLine(string message, ConsoleColor colour)
    {
        ConsoleColor col = Console.ForegroundColor;
        Console.ForegroundColor = colour;
        Console.WriteLine(message);
        Console.ForegroundColor = col;
    }

    /// <summary>
    /// Console.Write with colour input, sets colour back to origina after calling
    /// </summary>
    /// <param name="message">Message to display</param>
    /// <param name="colour">Consolecolour for text</param>
    public static void Write(string message, ConsoleColor colour)
    {
        ConsoleColor col = Console.ForegroundColor;
        Console.ForegroundColor = colour;
        Console.Write(message);
        Console.ForegroundColor = col;
    }
}