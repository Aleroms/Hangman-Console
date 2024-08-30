



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
    public static readonly string Banner = @"  _   _                                         
 | | | | __ _ _ __   __ _ _ __ ___   __ _ _ __  
 | |_| |/ _` | '_ \ / _` | '_ ` _ \ / _` | '_ \ 
 |  _  | (_| | | | | (_| | | | | | | (_| | | | |
 |_| |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_|
                    |___/       
";
    private static readonly string _line = "==============================================================";
    public void DisplayState(int lives, char[] displayedWords, string? guessedWords)
    {
        Console.Clear();
        DisplayBanner();

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
    public static void DisplayBanner()
    {
        Console.WriteLine(_line);
        Console.WriteLine(Banner);
        Console.WriteLine(_line);
    }
}