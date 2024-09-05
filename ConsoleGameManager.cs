

using System.Text.RegularExpressions;

public class ConsoleGameManager : GameManager
{
    private readonly SetupManager _setupManager;
    private readonly IWordGenerator _wordGenerator;
    private readonly IPlayerInputHandler _playerInputHandler;
    private readonly IHangman _hangman;
    private readonly IStorage _storage;

    public ConsoleGameManager(
        SetupManager setupManager,
        IWordGenerator wordGenerator,
        IPlayerInputHandler playerInputHandler,
        IHangman hangman,
        IStorage storage)
    {
        _setupManager = setupManager;
        _wordGenerator = wordGenerator;
        _playerInputHandler = playerInputHandler;
        _hangman = hangman;
        _storage = storage;

    }

    public override void FetchWord()
    {

        ConsoleFormatting.WriteColored("starting to fetch word...", ConsoleColor.Yellow);
        masterWord = _wordGenerator.GenerateWord(gameDifficulty);

        if (string.IsNullOrEmpty(masterWord))
        {
            ConsoleFormatting.WriteColored(
                "Failed to generate a word or received an empty string.",
                System.ConsoleColor.Red);
            return;
        }

        displayWord = new char[masterWord.Length];

        for (int i = 0; i < masterWord.Length; i++)
        {
            displayWord[i] = '_';
        }

    }

    public override void Reset()
    {
        Console.Clear();
        guessedWords = "";
        _playerInputHandler.ResetLives();
        gameDifficulty = _setupManager.GetDifficulty();
    }

    public override void Run()
    {
        bool playAgain = false;

        do
        {
            FetchWord();

            while (!IsGameOver(_playerInputHandler.Lives))
            {
                _hangman.DisplayState(_playerInputHandler.Lives, displayWord, guessedWords);

                if (!EvaluateGuess(_playerInputHandler.GetPlayerGuess()))
                    _playerInputHandler.Lives--;

            }
            _hangman.DisplayState(_playerInputHandler.Lives, displayWord, guessedWords);

            if (_playerInputHandler.Lives < 1)
            {
                ConsoleFormatting.WriteColored("YOU LOSE", ConsoleColor.Magenta);
                Console.WriteLine($"The word was {masterWord}");
            }
            else
            {
                _playerInputHandler.Victories++;
                ConsoleFormatting.WriteColored(
                    "WINNER WINNER CHICKEN DINNER!\n"
                    + $"\nGAMES WON {_playerInputHandler.Victories}",
                    ConsoleColor.Green);

                _storage.Write("victories.txt", _playerInputHandler.Victories.ToString());
            }
            playAgain = _playerInputHandler.GetPlayAgain();

            if (playAgain) 
            {
                Reset();
            }
            
        } while (playAgain);

    }

    public override void Setup()
    {
        //load victories
        _playerInputHandler.Victories = int.Parse(_storage.Read("victories.txt"));
        gameDifficulty = _setupManager.GetDifficulty();

    }

}
public static class ConsoleFormatting
{
    public static void WriteColored(string message, ConsoleColor consoleColor, bool newLine = true)
    {
        Console.ForegroundColor = consoleColor;

        if (newLine)
        {
            Console.WriteLine(message);
        }
        else
        {
            Console.Write(message);
        }

        Console.ResetColor();
    }

}