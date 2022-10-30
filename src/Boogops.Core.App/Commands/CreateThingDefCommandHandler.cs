using Boogops.Core.Domain.Commands;
using Boogops.Core.Domain.Entities;
using Boogops.Core.Domain.Repositories;

namespace Boogops.Core.App.Commands;

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
            var thingDef = ThingDef.Create(command.Name, command.Props);
            await _thingDefsRepository.CreateAsync(thingDef);
        }
        catch (Exception e)
        {
            retval = CoreResultFactory.CreateFailedResult(
                new CoreError { Message = e.Message });
        }

        return retval;
    }
}