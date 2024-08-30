using JetBrains.Annotations;

namespace Blackhawks.Dto;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public record PlayerDto
{
    public int Id { get; init; }
    public int ShirtNumber { get; init; }
    public string GivenName { get; init; } = "";
    public string FamilyName { get; init; } = "";
    public string Position { get; init; } = "";
    public string Shoots { get; init; } = "";
    
    public int Height { get; init; }
    
    public int Weight { get; init; }
    public DateOnly Birthday { get; init; }
    
    public string Wobble { get; init; } = "Not Set";
    
    public string Birthplace { get; init; } = "Not Set";
}
