using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

public class APIWordGenerator : IWordGenerator
{
    private static HttpClient _client = new HttpClient();

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
        return AWSBedrock.Sanitize(root.body.completion);
    }



}
public record Body_Meta(
    [property: JsonPropertyName("generation")] string generation,
    [property: JsonPropertyName("prompt_token_count")] int prompt_token_count,
    [property: JsonPropertyName("generation_token_count")] int generation_token_count,
    [property: JsonPropertyName("stop_reason")] string stop_reason
);

public record Root_Meta(
    [property: JsonPropertyName("statusCode")] int statusCode,
    [property: JsonPropertyName("body")] Body_Meta body
);

public record Body_Anthropic(
    [property: JsonPropertyName("type")] string type,
        [property: JsonPropertyName("completion")] string completion,
        [property: JsonPropertyName("stop_reason")] string stop_reason,
        [property: JsonPropertyName("stop")] string stop
);

public record Root_Anthropic(
    [property: JsonPropertyName("statusCode")] int statusCode,
    [property: JsonPropertyName("body")] Body_Anthropic body
);

public enum FoundationalModel { META_LLAMA3, ANTHROPIC_CLAUDE1 }

public static class AWSBedrock
{
    public static FoundationalModel FoundationalModel { get; set; }
    public static string ModelPrompt(string difficulty)
    {
        string promptFormat = "";
        switch (FoundationalModel)
        {
            case FoundationalModel.META_LLAMA3:
                promptFormat = "wordGenerate?hangman_prompt=%3C%7Cbegin_of_text%7C%3E%3C%"
            + "7Cstart_header_id%7C%3Esystem%3C%7Cend_header_id%7C%3E%20You%20are%20a%20helpful%20AI%20assistant%20"
            + "for%20generating%20unqiue%20words%20to%20be%20used%20in%20Hangman.%20Your%20response%20should%20only%20be"
            + "%20a%20single%20lowercased%20word%3C%7Ceot_id%7C%3E%3C%7Cstart_header_id%7C%3Euser%3C%7Cend_header_id%7C%3Egenerate"
            + $"%20an%20{difficulty}%20word%20in%20English%3C%7Ceot_id%7C%3E%3C%7Cstart_header_id%7C%3Eassistant%3C%7Cend_header_id%7C%3E";
                break;
            case FoundationalModel.ANTHROPIC_CLAUDE1:
                promptFormat = $"wordGenerate?hangman_prompt=%5Cn%5CnHuman%3Agenerate%20an%20{difficulty}%20English%20word."
                    + "%20Only%20return%20a%20single%20word!%5Cn%5CnAssistant%3A";
                break;
        }
        return promptFormat;
    }
    public static string Sanitize(string text) =>
        FoundationalModel == FoundationalModel.META_LLAMA3 ? Regex.Replace(text, @"[^a-z]", "") :
        FoundationalModel == FoundationalModel.ANTHROPIC_CLAUDE1 ? Regex.Replace(text, @"[^a-z]", "")
        : text;

    

}