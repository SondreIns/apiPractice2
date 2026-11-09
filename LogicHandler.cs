using apiPractice2.DataHandler;
using ConsoleHelper;

namespace apiPractice2;

public class LogicHandler
{
    public async void Begin()
    {
        ConsoleWriter.WriteLine("Houses or characters?:", ConsoleColor.Yellow);
        string? input = Console.ReadLine();
        if(!string.Equals("1", input) && !string.Equals("2", input))
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
        string baseAdress = "https://anapioficeandfire.com/api/";
        string housesUri = "houses/";
        string charactersUri = "characters/";
        Random rand = new Random();
        string num = houses ? rand.Next(1, 445).ToString() : rand.Next(1, 2135).ToString();
        string requestUri = houses ? housesUri + num : charactersUri + num;


        IApiDataReader dataReader = new ApiDataReader();
        string json = await dataReader.Read(baseAdress, requestUri);

        Console.WriteLine("Waiting for data..");
        Console.WriteLine(json);

    }
}