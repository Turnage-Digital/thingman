using Newtonsoft.Json;

namespace ThingMan.Core.Commands;

public abstract class Command : ICommand
{
    [JsonProperty("traceId")]
    public Guid TraceId { get; set; } = Guid.NewGuid();

    public override string ToString()
    {
        var retval = JsonConvert.SerializeObject(this);
        return retval;
    }
}