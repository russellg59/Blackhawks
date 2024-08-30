using Blackhawks.Dto;
using Blackhawks.Models;

namespace Blackhawks.Mappers;

public static class DtoExtensions
{
    public static Player ToPlayerModel(this PlayerDto dto)
    {
        return new Player
        {
            Id = dto.Id,
            ShirtNumber = dto.ShirtNumber,
            GivenName = dto.GivenName,
            FamilyName = dto.FamilyName,
            Position = dto.Position,
            Shoots = dto.Shoots,
            Birthday = dto.Birthday,
            Height = dto.Height,
            Weight = dto.Weight,
            Birthplace = dto.Birthplace
        };
    }
}