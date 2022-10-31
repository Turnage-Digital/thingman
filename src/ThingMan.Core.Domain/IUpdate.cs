namespace ThingMan.Core.Domain;

public interface IUpdate<in TAggregateRoot>
{
    Task UpdateAsync(TAggregateRoot entity);
}