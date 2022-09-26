using Boogops.Core.Domain.Entities;

namespace Boogops.Core.Domain.Repositories;

public interface IThingDefsRepository<TThingDef> : IRead<TThingDef>, ICreate<TThingDef> 
    where TThingDef : IAggregateRoot { }