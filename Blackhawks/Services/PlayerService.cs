using System.Net.Http.Json;
using Blackhawks.DataAccess;
using Blackhawks.Dto;

namespace Blackhawks.Services;

public class PlayerService : IPlayerService
{
    private const string PlayersFileUrl = "sample-data/players-004.json";
    private readonly Task _playersLoaded;
    private IEnumerable<PlayerDto>? _players;
    
    

    public PlayerService(HttpClient client)
    {
       _playersLoaded =  LoadPlayers(client);
    }

    public async Task<PlayerDto[]> GetPlayersAsync()
    {
        await _playersLoaded;
        return _players?.ToArray() ?? Array.Empty<PlayerDto>();
    }

    private async  Task LoadPlayers(HttpClient client)
    { 
        var players = await client.GetFromJsonAsync<PlayerDto[]>(PlayersFileUrl);
        _players = players;
    }
}
