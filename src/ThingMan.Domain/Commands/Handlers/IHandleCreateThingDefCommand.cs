using ThingMan.Core.Commands;
using ThingMan.Domain.Entities;

namespace ThingMan.Domain.Commands.Handlers;

public interface IHandleCreateThingDefCommand :
    IHandleCommand<CreateThingDefCommand, ThingDef> { }