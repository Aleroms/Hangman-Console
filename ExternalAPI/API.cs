using Hangman.AI;
using Hangman.CloudInfrastructure;
using Hangman.GameCore;
using System.Text.Json;

namespace Hangman.ExternalAPI
{

    public class APIWordGenerator : IWordGenerator
    {
        private static readonly HttpClient _client = new();

        public APIWordGenerator(FoundationalModel model)
        {
            _client.BaseAddress = new Uri("https://6owlahqw42.execute-api.us-east-1.amazonaws.com/dev/");
            AWSBedrock.FoundationalModel = model;
        }
        public string GenerateWord(GameDifficulty game)
        {
            string difficulty = game.ToString();


            using HttpResponseMessage response = _client.GetAsync(AWSBedrock.ModelPrompt(difficulty))
                .GetAwaiter().GetResult();

            response.EnsureSuccessStatusCode();
            var word = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var root = JsonSerializer.Deserialize<Root_Anthropic>(word);

            if (root == null)
                return "";

            // sanitize response 
            return AWSBedrock.Sanitize(root.Body.AIResponse);
        }



    }


}
