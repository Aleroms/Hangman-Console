

public class ConsoleGameManager : GameManager
{
    private readonly SetupManager _setupManager;
    private readonly IWordGenerator _wordGenerator;

    public ConsoleGameManager(SetupManager setupManager, IWordGenerator wordGenerator)
    {
        _setupManager = setupManager;
        _wordGenerator = wordGenerator;
    }

    public async override void FetchWord()
    {
        // connect to IWordGenerator and generate a word
        masterWord = await _wordGenerator.GenerateWord(_settings);
        displayWord = new char[masterWord.Length];
        
        for (int i = 0; i < masterWord.Length; i++)
        {
            displayWord[i] = '_';
        }
    }

    public override void Run()
    {
        throw new NotImplementedException();

    }

    public override void Setup()
    {
        // Get the settings and fetch the word
        _settings = _setupManager.GetSettings();
        FetchWord();
    }
}
