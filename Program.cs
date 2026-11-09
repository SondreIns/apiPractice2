namespace apiPractice2;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Get data about ASOIAF houses or characters.");
        LogicHandler handler = new LogicHandler();
        handler.Begin();
        Console.ReadKey();
    }
}
