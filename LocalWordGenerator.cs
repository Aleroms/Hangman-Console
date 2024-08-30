



public class LocalWordGenerator : IWordGenerator
{
    private Dictionary<GameDifficulty, List<char[]>> _wordList;

    public LocalWordGenerator()
    {
        _wordList = new();
        //EVENTUALLY IMPLEMENT ISTORAGE TO STORE THESE WORDS
        _wordList.Add(GameDifficulty.EASY, new List<char[]>
        {
            "cat".ToCharArray(),
            "sun".ToCharArray(),
            "book".ToCharArray(),
            "tree".ToCharArray(),
            "milk".ToCharArray(),
            "kite".ToCharArray(),
            "ball".ToCharArray(),
            "duck".ToCharArray(),
            "fish".ToCharArray(),
            "moon".ToCharArray(),
        });

        _wordList.Add(GameDifficulty.MEDIUM, new List<char[]>
        {
            "penguin".ToCharArray(),
            "kitchen".ToCharArray(),
            "blanket".ToCharArray(),
            "pumpkin".ToCharArray(),
            "lantern".ToCharArray(),
            "picture".ToCharArray(),
            "glasses".ToCharArray(),
            "chicken".ToCharArray(),
            "monster".ToCharArray(),
            "diamond".ToCharArray(),
        });

        _wordList.Add(GameDifficulty.HARD, new List<char[]>
        {
            "crocodile".ToCharArray(),
            "astronaut".ToCharArray(),
            "zucchini".ToCharArray(),
            "javascript".ToCharArray(),
            "kangaroo".ToCharArray(),
            "hierarchy".ToCharArray(),
            "xylophone".ToCharArray(),
            "microwave".ToCharArray(),
            "quarantine".ToCharArray(),
            "philosopher".ToCharArray(),
        });
    }
    public Task<char[]> GenerateWord(GameDifficulty game)
    {
        var matchingWords = _wordList[game].ToList();

        if (!matchingWords.Any())
            return Task.FromResult<char[]>(null);

        var random = new Random();
        return Task.FromResult(matchingWords[random.Next(matchingWords.Count)]);
    }

    
}