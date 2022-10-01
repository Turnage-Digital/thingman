using Boogops.Core.Events;
using Newtonsoft.Json;

namespace Boogops.Core.Domain;

public class Event : IEvent
{
    [JsonProperty("TraceId")]
    public Guid TraceId { get; set; } = Guid.NewGuid();

    public override string ToString()
    {
        var retval = JsonConvert.SerializeObject(this);
        return retval;
    }
}