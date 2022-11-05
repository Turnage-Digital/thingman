using ThingMan.Core;

namespace ThingMan.Domain;

public interface IRead<TAggregateRoot>
    where TAggregateRoot : IAggregateRoot
{
    Task<TAggregateRoot?> ReadAsync(string id);
}