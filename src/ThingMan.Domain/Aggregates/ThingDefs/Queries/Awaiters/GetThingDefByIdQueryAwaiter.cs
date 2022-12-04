using ThingMan.Core;
using ThingMan.Core.Queries;
using ThingMan.Domain.Aggregates.ThingDefs.Dtos;

namespace ThingMan.Domain.Aggregates.ThingDefs.Queries.Awaiters;

internal class GetThingDefByIdQueryAwaiter : IAwaitQuery<GetThingDefByIdQuery, ThingDefDto>
{
    private readonly IThingDefsView _thingDefsView;

    public GetThingDefByIdQueryAwaiter(IThingDefsView thingDefsView)
    {
        _thingDefsView = thingDefsView;
    }

    public string Name => nameof(GetThingDefByIdQueryAwaiter);

    public async Task<CoreResponse<ThingDefDto>> AwaitAsync(GetThingDefByIdQuery query)
    {
        CoreResponse<ThingDefDto> retval;

        try
        {
            var result = await _thingDefsView.GetById(query.Id);
            retval = CoreResponse<ThingDefDto>.CreateSuccessfulResponseWithResult(result);
        }
        catch (Exception e)
        {
            retval = CoreResponse<ThingDefDto>.CreateFailedResponse(
                new CoreError { Message = e.Message });
        }

        return retval;
    }
}