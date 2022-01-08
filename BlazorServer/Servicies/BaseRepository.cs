using BlazorServer.Models;
using BlazorServer.Static;
using Newtonsoft.Json;

namespace BlazorServer.Servicies;
public class BaseRepository : IBaseRepository
{
    private readonly IHttpClientFactory _client;

    public BaseRepository(IHttpClientFactory client)
    {
        _client = client;
    }

    public async Task<List<UserUI>> GetAll()
    {
        HttpRequestMessage request = new(HttpMethod.Get, Endpoints.GetUsers);

        var content = _client.CreateClient();

        HttpResponseMessage response = await content.SendAsync(request);
        if (!response.IsSuccessStatusCode)
            return null;

        var stringContent = await response.Content.ReadAsStringAsync();
        var users = JsonConvert.DeserializeObject<List<UserUI>>(stringContent);

        return users;
    }
}
