namespace ThingMan.Core.Domain;

public interface IDelete<in TAggregateRoot>
    where TAggregateRoot : IAggregateRoot
{
    Task DeleteAsync(TAggregateRoot entity);
}