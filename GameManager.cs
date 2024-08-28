

public abstract class GameManager
{
    protected WordSettings _settings;
    protected char[] masterWord;
    protected char[] displayWord;
    protected string guessedWords;
    protected char playerGuess;


    public abstract void Run();
    public abstract void Setup();
    public abstract void FetchWord();

    protected bool IsGameOver(int playerLives) => playerLives == 0 || masterWord.Length == 0;


}
