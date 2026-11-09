using System.Text.Json.Serialization;

public record HouseRoot(
    [property: JsonPropertyName("url")] string url,
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("region")] string region,
    [property: JsonPropertyName("coatOfArms")] string coatOfArms,
    [property: JsonPropertyName("words")] string words,
    [property: JsonPropertyName("titles")] IReadOnlyList<object> titles,
    [property: JsonPropertyName("seats")] IReadOnlyList<string> seats,
    [property: JsonPropertyName("currentLord")] string currentLord,
    [property: JsonPropertyName("heir")] string heir,
    [property: JsonPropertyName("overlord")] string overlord,
    [property: JsonPropertyName("founded")] string founded,
    [property: JsonPropertyName("founder")] string founder,
    [property: JsonPropertyName("diedOut")] string diedOut,
    [property: JsonPropertyName("ancestralWeapons")] IReadOnlyList<object> ancestralWeapons,
    [property: JsonPropertyName("cadetBranches")] IReadOnlyList<object> cadetBranches,
    [property: JsonPropertyName("swornMembers")] IReadOnlyList<string> swornMembers
);