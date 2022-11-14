using Newtonsoft.Json;
using ThingMan.Core.Queries;

namespace ThingMan.Domain.Queries;

public class GetThingDefByIdQuery : Query
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;
}