using ThingMan.Core;
using ThingMan.Domain.Dtos;
using ThingMan.Domain.Views;

namespace ThingMan.Domain.Queries.Awaiters;

public class GetThingDefByIdQueryAwaiter : IAwaitGetThingDefByIdQuery
{
    private readonly IThingDefsView _thingDefsView;

    public GetThingDefByIdQueryAwaiter(IThingDefsView thingDefsView)
    {
        _thingDefsView = thingDefsView;
    }

    public string Name => nameof(GetThingDefByIdQueryAwaiter);

    public async Task<QueryResult<ThingDefDto>> AwaitAsync(GetThingDefByIdQuery query)
    {
        QueryResult<ThingDefDto> retval;

        try
        {
            var results = await _thingDefsView.GetById(query.Id);
            retval = QueryResultFactory.CreateSuccessfulResult(results);
        }
        catch (Exception e)
        {
            retval = QueryResultFactory.CreateFailedResult<ThingDefDto>(
                new CoreError { Message = e.Message });
        }

        return retval;
    }
}