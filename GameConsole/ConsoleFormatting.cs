namespace Hangman.GameConsole;

public static class ConsoleFormatting
{
    public static void WriteColored(string message, ConsoleColor consoleColor, bool newLine = true)
    {
        Console.ForegroundColor = consoleColor;

        if (newLine)
        {
            Console.WriteLine(message);
        }
        else
        {
            Console.Write(message);
        }

        Console.ResetColor();
    }

}
