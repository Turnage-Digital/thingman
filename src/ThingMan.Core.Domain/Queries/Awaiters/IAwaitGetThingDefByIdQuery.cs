using ThingMan.Core.Domain.Dtos;
using ThingMan.Core.Queries;

namespace ThingMan.Core.Domain.Queries.Awaiters;

public interface IAwaitGetThingDefByIdQuery :
    IAwaitQuery<GetThingDefByIdQuery, ThingDefDto> { }