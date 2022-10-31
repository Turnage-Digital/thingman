using ThingMan.Core.Domain.Entities;

namespace ThingMan.Core.Domain.Repositories;

public interface IThingDefsRepository<TThingDef> : IRead<TThingDef>, ICreate<TThingDef>
    where TThingDef : ThingDef { }