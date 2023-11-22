using System.Text;
using System.Text.Json;

namespace Infrastructure.Utilities;


public interface IHttpClientFactory
{
    HttpClient CreateClient();
}

public class HttpClientFactory : IHttpClientFactory
{
    public HttpClient CreateClient()
    {
        var client = new HttpClient();
        // Configure client here if needed
        return client;
    }
}


public interface IHttpClientUtility
{
    Task<T> GetAsync<T>(string url);
    Task<T> PostAsync<T>(string url, object data);
    Task<T> PutAsync<T>(string url, object data);
    Task<T> DeleteAsync<T>(string url);
}

public class HttpClientUtility : IHttpClientUtility
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpClientUtility(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<T> GetAsync<T>(string url)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);

    }

    public async Task<T> PostAsync<T>(string url, object data)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.PostAsync(url, new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"));
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);
    }

    public async Task<T> PutAsync<T>(string url, object data)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.PutAsync(url, new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"));
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);
    }

    public async Task<T?> DeleteAsync<T>(string url)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content); 
    }

}
