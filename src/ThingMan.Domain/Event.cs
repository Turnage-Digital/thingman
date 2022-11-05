using Newtonsoft.Json;
using ThingMan.Core.Events;

namespace ThingMan.Domain;

public abstract class Event : IEvent
{
    [JsonProperty("TraceId")]
    public Guid TraceId { get; set; } = Guid.NewGuid();

    public override string ToString()
    {
        var retval = JsonConvert.SerializeObject(this);
        return retval;
    }
}