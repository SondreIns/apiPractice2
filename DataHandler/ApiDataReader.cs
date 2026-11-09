namespace apiPractice2.DataHandler;

public class ApiDataReader : IApiDataReader
{
    public async Task<string> Read(string baseAdress, string requestUri)
    {
        using HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(baseAdress);
        HttpResponseMessage response = await client.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}