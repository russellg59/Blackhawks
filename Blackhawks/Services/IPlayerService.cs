using Blackhawks.Dto;

namespace Blackhawks.Services;

public interface IPlayerService
{
    Task<PlayerDto[]> GetPlayersAsync();
}