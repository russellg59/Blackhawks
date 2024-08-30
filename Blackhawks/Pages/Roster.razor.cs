using Blackhawks.DataAccess;
using Blackhawks.Dto;
using Blackhawks.Mappers;
using Blackhawks.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;

namespace Blackhawks.Pages;

[UsedImplicitly]
public partial class Roster
{
    [Inject] 
    public IPlayerService? PlayerService { get; set; } = null;

    public IQueryable<Player>? Players { get; private set; }

    protected override async Task OnInitializedAsync()
    {
        var players = await PlayerService!.GetPlayersAsync();
        
        Players = players.Select(p => p.ToPlayerModel())
            .ToArray()
            .AsQueryable();
    }
}