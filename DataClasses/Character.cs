namespace apiPractice2.DataClasses;

public readonly record struct Character
{
    public string Name { get; }
    public string? Gender { get; }
    public string? Culture { get; }
    public string? Born { get; }
    public string? Died { get; }
    public string? FatherName { get;}
    public string? MotherName { get;}
    public string? SpouseName { get;}

    public Character(string name, string? gender, string? culture, string? born, string? died, Character? father, Character? mother, Character? spouse)
    {
        Name = name;
        Gender = NullCheck(gender);
        Culture = NullCheck(culture);
        Born = NullCheck(born);
        Died = NullCheck(died);
        FatherName = father != null ? father?.Name : "not found";
        MotherName = mother != null ? mother?.Name : "not found";
        SpouseName = spouse != null ? spouse?.Name : "not found";
    }

    public static explicit operator Character(CharacterRoot root)
    {
        string name = root.name;
        string? gender = root.gender;
        string? culture = root.culture;
        string? born = root.born;
        string? died = root.died;

        return new Character(name, gender, culture, born, died, null, null, null);
    }

    private string? NullCheck(string? input) => input != null ? input : "not found";
}