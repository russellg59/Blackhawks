using Blackhawks.Dto;

namespace Blackhawks.DataAccess;

public interface IPlayerService
{
    Task<PlayerDto[]> GetPlayersAsync();
}