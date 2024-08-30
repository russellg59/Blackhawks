using Blackhawks.Utilities;
using JetBrains.Annotations;

namespace Blackhawks.Models;

[UsedImplicitly(ImplicitUseTargetFlags.Members)]
public class Player
{
    public int Id { get; init; }
    
    public int ShirtNumber { get; init; }
    public string GivenName { get; init; } = "";
    public string FamilyName { get; init; } = "";
    
    public string Position { get; init; } = "";
    
    public string Shoots { get; init; } = "";
    
    public DateOnly Birthday { get; init; }
    
    public int Height { get; init; } = 0;
    
    public int Weight { get; init; } = 0;
    
    public string Birthplace { get; init; } = "";
    
    public string FullName => $"{GivenName} {FamilyName}";
    
    public int Age => Birthday.GetCurrentAge();
    
    public string DisplayHeight => $"{Height / 12}' {Height % 12}\"";
    
    public string DisplayWeight => $"{Weight}lbs";
    
    public string DisplayAge => $"{Birthday:dd MMM, yyyy} ({Age})";

    public string DisplayShirtNumber => ShirtNumber <= 0 ? "--" : ShirtNumber.ToString().PadLeft(2, ' ');
}