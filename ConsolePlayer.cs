

using System.Text.RegularExpressions;

public class ConsolePlayer : IPlayerInputHandler
{
    public int Lives { get; set; }

    public ConsolePlayer()
    {
        Lives = 6;
    }
    public char GetPlayerGuess()
    {
        while (true)
        {
            Console.Write("Guess a letter: ");
            string? input = Console.ReadLine();

            // Validate input: not null/empty, length is 1, and it's alphabetic
            if (!string.IsNullOrEmpty(input) && input.Length == 1 && char.IsLetter(input[0]))
            {
                return input[0];
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single alphabetic letter.");
            }
        }
    }
}