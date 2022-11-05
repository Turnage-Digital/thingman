using ThingMan.Core.Domain.Dtos;

namespace ThingMan.Core.Domain.Views;

public interface IThingDefsView
{
    Task<ThingDefDto> GetById(string id);
}