using Newtonsoft.Json;

namespace ThingMan.Core.Events;

public abstract class Event : IEvent
{
    [JsonProperty("traceId")]
    public Guid TraceId { get; set; } = Guid.NewGuid();

    public override string ToString()
    {
        var retval = JsonConvert.SerializeObject(this);
        return retval;
    }
}