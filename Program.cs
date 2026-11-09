namespace apiPractice2;

class Program
{
    static void Main(string[] args)
    {
        LogicHandler handler = new LogicHandler();
        handler.Begin();
        Console.ReadKey();
    }
}
