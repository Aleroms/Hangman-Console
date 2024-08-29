

public abstract class GameManager
{
    protected WordSettings _settings;
    protected char[] masterWord;
    protected char[] displayWord;
    protected string guessedWords;


    public abstract void Run();
    public abstract void Setup();
    public abstract void FetchWord();

    protected bool IsGameOver(int playerLives) => playerLives == 0 || masterWord.Length == 0;

    protected bool EvaluateGuess(char guess)
    {
        char marker = '@';
        int frequency = 0;

        //checks if guess is in word
        for (int i = 0; i < masterWord.Length; i++)
        {
            if (masterWord[i] == guess)
            {
                frequency++;
                displayWord[i] = guess;
                masterWord[i] = marker;
            }
        }

        if (frequency > 0)
        {
            var newWord = new char[masterWord.Length - frequency];
            int seek = 0, index = 0;
            while (seek < masterWord.Length)
            {
                if (masterWord[seek] != marker)
                    newWord[index++] = masterWord[seek];

                seek++;
            }
            masterWord = newWord;
            return true;
        }
        return false;
    }


}
