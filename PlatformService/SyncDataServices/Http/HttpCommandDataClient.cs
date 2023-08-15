using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http;

public class HttpCommandDataClient : ICommandDataClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task SendPlatformToCommand(PlatformReadDto platform)
    {
        var stringContent = new StringContent(JsonSerializer.Serialize(platform), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_configuration["CommandService"], stringContent);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Sync POST to command service is OK");
        }
        else
        {
            Console.WriteLine("Sync POST to command service is not OK");
        }
    }
}