namespace ThingMan.Core;

public interface IRead<TAggregateRoot>
    where TAggregateRoot : IAggregateRoot
{
    Task<TAggregateRoot?> ReadAsync(string id);
}