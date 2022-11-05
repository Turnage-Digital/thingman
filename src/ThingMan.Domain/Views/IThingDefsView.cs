using ThingMan.Domain.Dtos;

namespace ThingMan.Domain.Views;

public interface IThingDefsView
{
    Task<ThingDefDto> GetById(string id);
}