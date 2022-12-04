using Newtonsoft.Json;
using ThingMan.Core.Events;

namespace ThingMan.Domain.Aggregates.ThingDefs.Events;

public class ThingDefCreatedEvent : Event
{
    [JsonProperty("thingDef")]
    public ThingDef ThingDef { get; set; } = null!;
}