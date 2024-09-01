﻿

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
        // handle logic for nulls
        Console.WriteLine("Starting to fetch word...");
        masterWord = _wordGenerator.GenerateWord(gameDifficulty);

        if (string.IsNullOrEmpty(masterWord))
        {
            Console.WriteLine("Failed to generate a word or received an empty string.");
            return;
        }

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

        if (_playerInputHandler.Lives < 1)
        {
            Console.WriteLine("YOU LOSE");
            Console.WriteLine($"The word was {masterWord}");
        }
        else
        {
            _playerInputHandler.Victories++;
            Console.WriteLine("WINNER WINNER CHICKEN DINNER!\n" +
                $"\nGAMES WON {_playerInputHandler.Victories}");
            _storage.Write("victories.txt", _playerInputHandler.Victories.ToString());
        }

    }

    public override void Setup()
    {
        //load victories
        _playerInputHandler.Victories = int.Parse(_storage.Read("victories.txt"));

        gameDifficulty = _setupManager.GetDifficulty();
        FetchWord();
    }
}
