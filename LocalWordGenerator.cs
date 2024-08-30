



public class LocalWordGenerator : IWordGenerator
{
    private Dictionary<GameDifficulty, List<string>> _wordList;

    public LocalWordGenerator()
    {
        _wordList = new();
        //EVENTUALLY IMPLEMENT ISTORAGE TO STORE THESE WORDS
        _wordList.Add(GameDifficulty.EASY, new List<string>
        {
            "cat",
            "sun",
            "book",
            "tree",
            "milk",
            "kite",
            "ball",
            "duck",
            "fish",
            "moon",
        });

        _wordList.Add(GameDifficulty.MEDIUM, new List<string>
        {
            "penguin",
            "kitchen",
            "blanket",
            "pumpkin",
            "lantern",
            "picture",
            "glasses",
            "chicken",
            "monster",
            "diamond",
        });

        _wordList.Add(GameDifficulty.HARD, new List<string>
        {
            "crocodile",
            "astronaut",
            "zucchini",
            "javascript",
            "kangaroo",
            "hierarchy",
            "xylophone",
            "microwave",
            "quarantine",
            "philosopher",
        });
    }
    public Task<string> GenerateWord(GameDifficulty game)
    {
        var matchingWords = _wordList[game];

        if (!matchingWords.Any())
            return Task.FromResult<string>("");

        var random = new Random();
        return Task.FromResult(matchingWords[random.Next(matchingWords.Count)]);
    }


}