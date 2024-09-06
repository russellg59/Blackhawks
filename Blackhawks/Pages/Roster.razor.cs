using Blackhawks.Dto;
using Blackhawks.Mappers;
using Blackhawks.Models;
using Blackhawks.Services;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;

namespace Blackhawks.Pages;

[UsedImplicitly]
public partial class Roster
{
    private static readonly List<string> ForwardPositions = ["RW", "LW", "C"];
    private static readonly List<string> DefencePositions = ["D"];
    private static readonly List<string> GoaliePositions = ["G"];
    
    private const string AllPlayersFilterTag = "All";
    private const string GoaliesFilterTag = "Goalies";
    private const string ForwardsFilterTag = "Forwards";
    private const string DefendersFilterTag = "Defenders";
    
    private Player[]? _players;
    
    [Inject] 
    public IPlayerService? PlayerService { get; set; } = null;

    public IQueryable<Player>? FilteredPlayersList { get; private set; }
    
    public string FilterTag { get; set; } = AllPlayersFilterTag;

    protected override async Task OnInitializedAsync()
    {
        var players = await PlayerService!.GetPlayersAsync();

        _players = players.Select(p => p.ToPlayerModel())
            .ToArray();
        
        FilteredPlayersList = _players
            .ToList()
            .AsQueryable();
    }

    private void OnAllButtonClicked()
    {
        if (_players is null)
        {
            return;
        }
        
        FilteredPlayersList = _players.AsQueryable();
        FilterTag = AllPlayersFilterTag;

    }

    private void OnForwardsButtonClicked()
    {
        FilterOnPositions(ForwardPositions);
        FilterTag = ForwardsFilterTag;
    }

    private void OnDefenceClicked()
    {
        FilterOnPositions(DefencePositions);
        FilterTag = DefendersFilterTag;
    }

    private void OnNetmindersClicked()
    {
        FilterOnPositions(GoaliePositions);
        FilterTag = GoaliesFilterTag;
    }

    private void FilterOnPositions(IEnumerable<string> positions)
    {
        
        if (_players is not null)
        {
            FilteredPlayersList = _players
                .Where(p => positions.Contains(p.Position))
                .AsQueryable();
        }
    }
}