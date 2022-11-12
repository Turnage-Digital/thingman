using ThingMan.Core;
using ThingMan.Domain.Entities;
using ThingMan.Domain.Repositories;

namespace ThingMan.Domain.Commands.Handlers;

public class CreateThingDefCommandHandler : IHandleCreateThingDefCommand
{
    private readonly IThingDefsRepository<ThingDef> _thingDefsRepository;

    public CreateThingDefCommandHandler(IThingDefsRepository<ThingDef> thingDefsRepository)
    {
        _thingDefsRepository = thingDefsRepository;
    }

    public string Name => nameof(CreateThingDefCommandHandler);

    public async Task<CoreResult> HandleAsync(CreateThingDefCommand command)
    {
        var retval = CoreResult.Success;

        try
        {
            var thingDef = ThingDef.Create(command.UserId, command.Name, command.Props);
            await _thingDefsRepository.CreateAsync(thingDef);
        }
        catch (Exception e)
        {
            retval = CoreResult.CreateFailedResult(
                new CoreError { Message = e.Message });
        }

        return retval;
    }
}