using Hangman.GameCore;
namespace Hangman.Local
{
    public class LocalWordGenerator : IWordGenerator
    {
        private readonly Dictionary<GameDifficulty, List<string>> _wordList;

        public LocalWordGenerator()
        {
            _wordList = new()
            {
                //EVENTUALLY IMPLEMENT ISTORAGE TO STORE THESE WORDS
                {
                    GameDifficulty.EASY,
                    new List<string>
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
                    }
                },
                {
                    GameDifficulty.MEDIUM,
                    new List<string>
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
                    }
                },
                {
                    GameDifficulty.HARD,
                    new List<string>
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
                    }
                }
            };
        }
        public string GenerateWord(GameDifficulty game)
        {
            var matchingWords = _wordList[game];

            if (matchingWords.Count == 0)
                return "";

            var random = new Random();
            return matchingWords[random.Next(matchingWords.Count)];
        }


    }
    public class LocalStore : IStorage
    {
        public string Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileContents = File.ReadAllText(filePath);
                return fileContents;
            }
            return "0";
        }

        public void Write(string filePath, string data)
        {
            File.WriteAllText(filePath, data);
        }
    }
}
