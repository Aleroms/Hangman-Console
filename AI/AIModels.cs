using System.Text.Json.Serialization;

namespace Hangman.AI;

public record Body_Meta(
[property: JsonPropertyName("generation")] string AIResponse,
[property: JsonPropertyName("prompt_token_count")] int PromptTokenCount,
[property: JsonPropertyName("generation_token_count")] int GenerationTokenCount,
[property: JsonPropertyName("stop_reason")] string StopReason
);

public record Root_Meta(
    [property: JsonPropertyName("statusCode")] int StatusCode,
    [property: JsonPropertyName("body")] Body_Meta Body
);

public record Body_Anthropic(
    [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("completion")] string AIResponse,
        [property: JsonPropertyName("stop_reason")] string StopReason,
        [property: JsonPropertyName("stop")] string Stop
);

public record Root_Anthropic(
    [property: JsonPropertyName("statusCode")] int StatusCode,
    [property: JsonPropertyName("body")] Body_Anthropic Body
);
