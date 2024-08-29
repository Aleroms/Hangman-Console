

public class ConsoleGameManager : GameManager
{
    private readonly SetupManager _setupManager;
    private readonly IWordGenerator _wordGenerator;
    private readonly IPlayerInputHandler _playerInputHandler;
    private readonly IHangman _hangman;

    public ConsoleGameManager(
        SetupManager setupManager,
        IWordGenerator wordGenerator,
        IPlayerInputHandler playerInputHandler,
        IHangman hangman)
    {
        _setupManager = setupManager;
        _wordGenerator = wordGenerator;
        _playerInputHandler = playerInputHandler;
        _hangman = hangman;

    }

    public async override void FetchWord()
    {
        masterWord = await _wordGenerator.GenerateWord(_settings);
        displayWord = new char[masterWord.Length];

        for (int i = 0; i < masterWord.Length; i++)
        {
            displayWord[i] = '_';
        }

    }

    public override void Run()
    {

        while (!IsGameOver(_playerInputHandler.Lives))
        {
            _hangman.DisplayState(_playerInputHandler.Lives, displayWord, guessedWords);

            if (!EvaluateGuess(_playerInputHandler.GetPlayerGuess()))
                _playerInputHandler.Lives--;

        }
        _hangman.DisplayState(_playerInputHandler.Lives, displayWord, guessedWords);

        if(_playerInputHandler.Lives < 1)
        {
            Console.WriteLine("YOU LOSE");
        }
        else
        {
            Console.WriteLine("WINNER WINNER CHICKEN DINNER!");
        }
    }

    public override void Setup()
    {
        // Get the settings and fetch the word
        _settings = _setupManager.GetSettings();
        FetchWord();
    }
}
