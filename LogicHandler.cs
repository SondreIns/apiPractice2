using System.Text.Json;
using apiPractice2.DataHandler;
using ConsoleHelper;

namespace apiPractice2;

public class LogicHandler
{
    //[root.name, root.gender, root.culture, root.born, root.died, root.father, root.mother, root.spouse];
    private string[] _houseEntries = ["Name: ", "Region: ", "Words: ", "Current ruler: "];
    private string[] _characterEntries = ["Name: ", "Gender: ", "Culture: ", "Born: ", "Died: ", "Father: ", "Mother: ", "Spouse: "];
    private ConsoleColor[] _houseCols = [ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Cyan];
    private ConsoleColor[] _charCols = [ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Magenta,
                                        ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.Cyan, ConsoleColor.DarkRed];

    private string _baseAdress = "https://anapioficeandfire.com/api/";
    private string _housesUri = "houses/";
    private string _charactersUri = "characters/";


    public async void Begin()
    {
        ConsoleWriter.WriteLine("Houses or characters?:", ConsoleColor.Yellow);
        string? input = Console.ReadLine();
        if (!string.Equals("1", input) && !string.Equals("2", input))
        {
            Console.Clear();
            ConsoleWriter.WriteLine("Error - input a vaid choice", ConsoleColor.Red);
            Begin();
        }
        else
        {
            Console.Clear();
            bool houses = string.Equals("1", input);
            await Run(houses);
        }
    }
    private async Task Run(bool houses)
    {
        Random rand = new Random();
        string num = houses ? rand.Next(1, 445).ToString() : rand.Next(1, 2135).ToString();
        string requestUri = houses ? _housesUri + num : _charactersUri + num;


        IApiDataReader dataReader = new ApiDataReader();
        string json = await dataReader.Read(_baseAdress, requestUri);
        string[] data = houses ? await ParseHouseData(json) : await ParseCharacterData(json);
        string[] entries = houses ? _houseEntries : _characterEntries;
        ConsoleColor[] cols = houses ? _houseCols : _charCols;
        Console.WriteLine("Waiting for data..");
        if (data != null)
        {
            for (int i = 0; i < data.Length; i++)
            {
                ConsoleWriter.Write(entries[i], cols[i]);
                Console.Write(data[i] == string.Empty ? "not found.\n" : data[i] + "\n");
            }
        }
    }

    private async Task<string[]> ParseHouseData(string input)
    {
        HouseRoot? root = JsonSerializer.Deserialize<HouseRoot>(input);
        if (root != null) return [root.name, root.region, root.words, await ParseExtraChar(root.currentLord)];
        else return ["nameerror", "regionerror", "wordserror", "currentLorderror"];
    }

    private async Task<string[]> ParseCharacterData(string input)
    {
        CharacterRoot? root = JsonSerializer.Deserialize<CharacterRoot>(input);
        if (root != null)
        {
            string[] extraChars = [await ParseExtraChar(root.father), await ParseExtraChar(root.mother), await ParseExtraChar(root.spouse)];
            return [root.name, root.gender, root.culture, root.born, root.died, extraChars[0], extraChars[1], extraChars[2]];
        }
        else return ["nameerror", "gendererror", "cultureerror", "bornerror", "diederror", "fathererror", "mothererror", "spouseerror"];
    }

    private async Task<string> ParseExtraChar(string character)
    {
        IApiDataReader dataReader = new ApiDataReader();
        string link = string.Empty;
        for (int i = 34; i < character.Length; i++)
        {
            link += character[i];
        }
        if(link == string.Empty) return link;
        string spouse = await dataReader.Read(_baseAdress, link);
        CharacterRoot? root = JsonSerializer.Deserialize<CharacterRoot>(spouse);
        if (root != null) return root.name;
        return string.Empty;
    }

}