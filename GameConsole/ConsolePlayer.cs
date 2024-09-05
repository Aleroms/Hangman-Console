using Hangman.GameCore;
namespace Hangman.GameConsole;

public class ConsolePlayer : IPlayerInputHandler
{
    private static readonly int _defaultLives = 6;
    public int Lives { get; set; }
    public int Victories { get; set; }

    public ConsolePlayer()
    {
        Lives = _defaultLives;
    }
    public char GetPlayerGuess()
    {
        while (true)
        {
            Console.Write("Guess a letter: ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input) && input.Length == 1 && char.IsLetter(input[0]))
                return char.ToLower(input[0]);
            else
                ConsoleFormatting.WriteColored("Invalid input. Please enter a single alphabetic letter.",
                    ConsoleColor.Red);
        }
    }
    public bool GetPlayAgain()
    {
        while (true)
        {
            Console.Write("Play Again?\n1. Yes, 2. No: ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int result))
                return result == 1;
            else
                ConsoleFormatting.WriteColored("Invalid input. Please enter a single number.",
                    ConsoleColor.Red);
        }
    }

    public void ResetLives()
    {
        Lives = _defaultLives;
    }
}
