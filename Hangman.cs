



public interface IHangman
{
    public void DisplayState(int lives, char[] displayedWords, string guessedWords);
}

public class ConsoleHangman : IHangman
{
    private static readonly List<string> _state = new()
{
    @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|\  |
      |
=========",
    @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
    @"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
    @"
  +---+
  |   |
      |
      |
      |
      |
========="
};
    public void DisplayState(int lives, char[] displayedWords, string? guessedWords)
    {
        /*
        display current state
       display guessed_words(only if > 0)
       display displayWord(the underline hint ___)
        */
        Console.WriteLine(_state[lives]);
        if (guessedWords != null && guessedWords.Length > 0)
        {
            string displayGuessedLetters = string.Join(" ", guessedWords);
            Console.WriteLine($"Guessed Letters: {displayGuessedLetters}");
        }
        string word = "";
        foreach (char c in displayedWords) word += c;
        Console.WriteLine($"\nGuess Me: {word}");


    }
}