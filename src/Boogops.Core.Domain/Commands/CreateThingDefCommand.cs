using Boogops.Core.Domain.Entities;

namespace Boogops.Core.Domain.Commands;

public class CreateThingDefCommand : Command
{
    public CreateThingDefCommand(string name, PropDef[] props)
    {
        Name = name;
        Props = props;
    }
    
    public string Name { get; }

    public PropDef[] Props { get; }
}