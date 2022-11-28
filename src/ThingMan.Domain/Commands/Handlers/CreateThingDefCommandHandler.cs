using AutoMapper;
using ThingMan.Core;
using ThingMan.Core.Commands;
using ThingMan.Domain.Entities;
using ThingMan.Domain.Repositories;

namespace ThingMan.Domain.Commands.Handlers;

internal class CreateThingDefCommandHandler : IHandleCommand<CreateThingDefCommand, ThingDef>
{
    private readonly IMapper _mapper;
    private readonly IThingDefsRepository _thingDefsRepository;

    public CreateThingDefCommandHandler(
        IThingDefsRepository thingDefsRepository,
        IMapper mapper
    )
    {
        _thingDefsRepository = thingDefsRepository;
        _mapper = mapper;
    }

    public string Name => nameof(CreateThingDefCommandHandler);

    public async Task<CoreResponse<ThingDef>> HandleAsync(CreateThingDefCommand command)
    {
        CoreResponse<ThingDef> retval;

        try
        {
            var props = _mapper.Map<PropDef[]>(command.Props);
            var thingDef = ThingDef.Create(command.Name, command.UserId!, props);
            await _thingDefsRepository.CreateAsync(thingDef);
            retval = CoreResponse<ThingDef>.CreateSuccessfulResponseWithResult(thingDef);
        }
        catch (Exception e)
        {
            retval = CoreResponse<ThingDef>.CreateFailedResponse(
                new CoreError { Message = e.Message });
        }

        return retval;
    }
}