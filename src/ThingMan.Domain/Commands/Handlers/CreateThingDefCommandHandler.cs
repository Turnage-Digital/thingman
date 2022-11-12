using ThingMan.Core;
using ThingMan.Domain.Entities;
using ThingMan.Domain.Repositories;

namespace ThingMan.Domain.Commands.Handlers;

public class CreateThingDefCommandHandler : IHandleCreateThingDefCommand
{
    private readonly IThingDefsRepository _thingDefsRepository;

    public CreateThingDefCommandHandler(IThingDefsRepository thingDefsRepository)
    {
        _thingDefsRepository = thingDefsRepository;
    }

    public string Name => nameof(CreateThingDefCommandHandler);

    public async Task<CoreResponse> HandleAsync(CreateThingDefCommand command)
    {
        var retval = CoreResponse.Success;

        try
        {
            var thingDef = ThingDef.Create(command.Name, command.UserId, command.Props);
            await _thingDefsRepository.CreateAsync(thingDef);
        }
        catch (Exception e)
        {
            retval = CoreResponse.CreateFailedResponse(new CoreError { Message = e.Message });
        }

        return retval;
    }
}