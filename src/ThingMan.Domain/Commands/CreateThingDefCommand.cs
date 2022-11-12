using ThingMan.Core.Commands;
using ThingMan.Domain.Entities;

namespace ThingMan.Domain.Commands;

public class CreateThingDefCommand : Command
{
    public CreateThingDefCommand(string userId, string name, PropDef[] props)
    {
        UserId = userId;
        Name = name;
        Props = props;
    }

    public string UserId { get; }

    public string Name { get; }

    public PropDef[] Props { get; }
}