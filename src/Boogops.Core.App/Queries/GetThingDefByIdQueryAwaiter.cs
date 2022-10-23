using Boogops.Core.Stores.Dtos;
using Boogops.Core.Stores.Queries;
using Boogops.Core.Stores.Stores;

namespace Boogops.Core.App.Queries;

public class GetThingDefByIdQueryAwaiter : IAwaitGetThingDefByIdQuery
{
    private readonly IThingDefsStore _thingDefsStore;

    public GetThingDefByIdQueryAwaiter(IThingDefsStore thingDefsStore)
    {
        _thingDefsStore = thingDefsStore;
    }

    public string Name => nameof(GetThingDefByIdQueryAwaiter);

    public async Task<QueryResult<ThingDefDto>> AwaitAsync(GetThingDefByIdQuery query)
    {
        QueryResult<ThingDefDto> retval;

        try
        {
            var results = await _thingDefsStore.GetById(query.Id);
            retval = QueryResultFactory.CreateSuccessfulResult(results);
        }
        catch (Exception e)
        {
            retval = QueryResultFactory.CreateFailedResult<ThingDefDto>(new CoreError { Message = e.Message });
        }

        return retval;
    }
}