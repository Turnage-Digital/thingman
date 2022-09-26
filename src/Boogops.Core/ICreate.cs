namespace Boogops.Core;

public interface ICreate<TAggregateRoot>
    where TAggregateRoot : IAggregateRoot
{
    Task<CoreResult> CreateAsync(TAggregateRoot entity);
}