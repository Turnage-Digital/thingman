using Newtonsoft.Json;
using ThingMan.Core.Commands;

namespace ThingMan.Core.Domain;

public abstract class Command : ICommand
{
    [JsonProperty("TraceId")]
    public Guid TraceId { get; set; } = Guid.NewGuid();

    public override string ToString()
    {
        var retval = JsonConvert.SerializeObject(this);
        return retval;
    }
}