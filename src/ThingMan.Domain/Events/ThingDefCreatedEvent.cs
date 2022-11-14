using Newtonsoft.Json;
using ThingMan.Core.Events;
using ThingMan.Domain.Entities;

namespace ThingMan.Domain.Events;

public class ThingDefCreatedEvent : Event
{
    [JsonProperty("thingDef")]
    public ThingDef ThingDef { get; set; } = null!;
}