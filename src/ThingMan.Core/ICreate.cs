namespace ThingMan.Core;

public interface ICreate<in TAggregateRoot>
    where TAggregateRoot : IAggregateRoot
{
    Task CreateAsync(TAggregateRoot entity);
}