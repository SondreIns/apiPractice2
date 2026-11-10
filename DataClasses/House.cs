namespace apiPractice2.DataClasses;

public readonly record struct House
{
    public string Name { get; }
    public string? Region { get; }
    public string? Words { get; }
    public string? CurrentRulerName { get; }

    public House(string name, string? region, string? words, Character? currentRuler)
    {
        Name = name;
        Region = region != null ? region : "not found";
        Words = words != null ? words : "not found";
        CurrentRulerName = currentRuler != null ? currentRuler?.Name : "not found";
    } 
}