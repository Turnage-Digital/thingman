using Boogops.Core.Commands;
using Boogops.Core.Domain.Commands;

namespace Boogops.Core.App.Commands;

public interface IHandleCreateThingDefCommand :
    IHandleCommand<CreateThingDefCommand> { }