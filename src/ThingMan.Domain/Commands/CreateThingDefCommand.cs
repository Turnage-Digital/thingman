using ThingMan.Domain.Entities;

namespace ThingMan.Domain.Commands;

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