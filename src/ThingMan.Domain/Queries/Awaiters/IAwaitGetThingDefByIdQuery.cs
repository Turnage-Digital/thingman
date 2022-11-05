using ThingMan.Core.Queries;
using ThingMan.Domain.Dtos;

namespace ThingMan.Domain.Queries.Awaiters;

public interface IAwaitGetThingDefByIdQuery :
    IAwaitQuery<GetThingDefByIdQuery, ThingDefDto> { }