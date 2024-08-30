


public abstract class SetupManager
{
    public int WordLength { get; set; }
    public GameDifficulty GameMode { get; set; }

    public abstract GameDifficulty GetDifficulty();

}
