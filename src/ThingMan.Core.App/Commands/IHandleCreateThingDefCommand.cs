using ThingMan.Core.Commands;
using ThingMan.Core.Domain.Commands;

namespace ThingMan.Core.App.Commands;

public interface IHandleCreateThingDefCommand :
    IHandleCommand<CreateThingDefCommand> { }