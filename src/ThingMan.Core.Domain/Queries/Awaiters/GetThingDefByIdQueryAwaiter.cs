using ThingMan.Core.Domain.Dtos;
using ThingMan.Core.Domain.Views;

namespace ThingMan.Core.Domain.Queries.Awaiters;

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