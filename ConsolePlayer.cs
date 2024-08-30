

using System.Text.RegularExpressions;

public class ConsolePlayer : IPlayerInputHandler
{
    public int Lives { get; set; }
    public int Victories { get; set; }

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

            if (!string.IsNullOrEmpty(input) && input.Length == 1 && char.IsLetter(input[0]))
            {
                //return input[0];
                return char.ToLower(input[0]);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single alphabetic letter.");
            }
        }
    }
}