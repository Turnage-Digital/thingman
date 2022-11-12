using ThingMan.Core;

namespace ThingMan.Domain;

public interface ICreate<in TAggregateRoot>
    where TAggregateRoot : IAggregateRoot
{
    Task<CoreResult> CreateAsync(TAggregateRoot entity);
}