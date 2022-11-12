using ThingMan.Core;
using ThingMan.Domain.Entities;

namespace ThingMan.Domain.Repositories;

public interface IThingDefsRepository :
    IRead<ThingDef>, ICreate<ThingDef> { }