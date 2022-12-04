using ThingMan.Core;

namespace ThingMan.Domain.Aggregates.ThingDefs;

public interface IThingDefsRepository :
    IRead<ThingDef>, ICreate<ThingDef> { }