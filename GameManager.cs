

public abstract class GameManager
{
    protected WordSettings _settings;
    protected int _playerLives = 6;
    protected char[] masterWord;
    protected char[] displayWord;
    protected char playerGuess;

    public abstract void Run();
    public abstract void Setup();
    public abstract void FetchWord();

    protected bool IsGameOver() => _playerLives <= 0 && masterWord.Length < 0;


}
