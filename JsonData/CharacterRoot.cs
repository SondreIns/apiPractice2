using System.Text.Json.Serialization;

public record CharacterRoot(
    [property: JsonPropertyName("url")] string url,
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("gender")] string gender,
    [property: JsonPropertyName("culture")] string culture,
    [property: JsonPropertyName("born")] string born,
    [property: JsonPropertyName("died")] string died,
    [property: JsonPropertyName("titles")] IReadOnlyList<object> titles,
    [property: JsonPropertyName("aliases")] IReadOnlyList<object> aliases,
    [property: JsonPropertyName("father")] string father,
    [property: JsonPropertyName("mother")] string mother,
    [property: JsonPropertyName("spouse")] string spouse,
    [property: JsonPropertyName("allegiances")] IReadOnlyList<string> allegiances,
    [property: JsonPropertyName("books")] IReadOnlyList<string> books,
    [property: JsonPropertyName("povBooks")] IReadOnlyList<object> povBooks,
    [property: JsonPropertyName("tvSeries")] IReadOnlyList<object> tvSeries,
    [property: JsonPropertyName("playedBy")] IReadOnlyList<object> playedBy
);