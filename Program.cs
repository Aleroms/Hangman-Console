var gm = new ConsoleGameManager(
    new ConsoleSetupManager(),
    new LocalWordGenerator(),
    new ConsolePlayer(),
    new ConsoleHangman()
    );

try
{
    gm.Setup();
    gm.Run();
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}

Console.WriteLine("Press any key to continue");
Console.ReadKey();

public enum GameDifficulty { EASY, MEDIUM, HARD }
public struct WordSettings
{
    public int wordLength;
    public GameDifficulty difficulty;

    public WordSettings(int length, GameDifficulty difficulty)
    {
        wordLength = length;
        this.difficulty = difficulty;
    }
}

public interface IWordGenerator
{
    Task<char[]> GenerateWord(WordSettings ws);
}
public interface IPlayerInputHandler
{
    public char GetPlayerGuess();
    int Lives { get; set; }
}
