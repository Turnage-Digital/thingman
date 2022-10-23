using Boogops.Core.Stores.Dtos;
using Boogops.Core.Queries;
using Boogops.Core.Stores.Queries;

namespace Boogops.Core.App.Queries;

public interface IAwaitGetThingDefByIdQuery :
    IAwaitQuery<GetThingDefByIdQuery, ThingDefDto> { }