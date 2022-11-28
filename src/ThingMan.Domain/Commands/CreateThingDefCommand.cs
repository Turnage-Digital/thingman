using Newtonsoft.Json;
using ThingMan.Core.Commands;
using ThingMan.Domain.Dtos;

namespace ThingMan.Domain.Commands;

public class CreateThingDefCommand : Command
{
    public CreateThingDefCommand(string name, PropDefDto[] props)
    {
        Name = name;
        Props = props;
    }
    
    [JsonIgnore]
    public string? UserId { get; set; }

    [JsonProperty("name")]
    public string Name { get; }

    [JsonProperty("props")]
    public PropDefDto[] Props { get; }
}