using ThingMan.Core.Stores.Dtos;
using ThingMan.Core.Queries;
using ThingMan.Core.Stores.Queries;

namespace ThingMan.Core.App.Queries;

public interface IAwaitGetThingDefByIdQuery :
    IAwaitQuery<GetThingDefByIdQuery, ThingDefDto> { }