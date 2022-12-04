using ThingMan.Domain.Aggregates.ThingDefs.Dtos;

namespace ThingMan.Domain.Aggregates.ThingDefs;

public interface IThingDefsView
{
    Task<ThingDefDto> GetById(string id);
}