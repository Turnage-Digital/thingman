namespace ThingMan.Core.Domain;

public interface IRead<TAggregateRoot>
    where TAggregateRoot : IAggregateRoot
{
    Task<TAggregateRoot?> ReadAsync(string id);
}