using Boogops.Core.Domain.Commands;

namespace Boogops.Core.App.Commands;

public class CreateThingDefCommandHandler : IHandleCreateThingDefCommand
{
    public async Task<CoreResult> HandleAsync(CreateThingDefCommand command)
    {
        throw new NotImplementedException();
    }

    public string Name => nameof(CreateThingDefCommandHandler);
}