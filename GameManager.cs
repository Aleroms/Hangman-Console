﻿

public abstract class GameManager
{
    protected WordSettings _settings;
    protected char[] masterWord;
    protected char[] displayWord;
    protected string guessedWords = "";


    public abstract void Run();
    public abstract void Setup();
    public abstract void FetchWord();

    protected bool IsGameOver(int playerLives) => playerLives == 0 || IsMasterWordGuessed();

    protected bool EvaluateGuess(char guess)
    {
        bool isCorrectGuess = false;
        if (!guessedWords.Contains(guess))
            guessedWords += guess;

        for (int i = 0; i < masterWord.Length; i++)
        {
            if (masterWord[i] == guess)
            {
                displayWord[i] = guess;
                isCorrectGuess = true;
            }
        }
        return isCorrectGuess;
    }

    private bool IsMasterWordGuessed() =>
        new string(masterWord) == new string(displayWord);

}
