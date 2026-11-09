namespace apiPractice2.DataHandler;

public interface IApiDataReader
{
    Task<string> Read(string baseAdress, string requestUri);
}