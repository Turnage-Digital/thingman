using ThingMan.Domain.Entities;

namespace ThingMan.Domain.Repositories;

public interface IThingDefsRepository<TThingDef> : IRead<TThingDef>, ICreate<TThingDef>
    where TThingDef : ThingDef { }