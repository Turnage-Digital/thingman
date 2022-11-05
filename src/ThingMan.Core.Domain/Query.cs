using Newtonsoft.Json;
using ThingMan.Core.Queries;

namespace ThingMan.Core.Domain;

public abstract class Query : IQuery
{
    [JsonProperty("TraceId")]
    public Guid TraceId { get; set; } = Guid.NewGuid();

    public override string ToString()
    {
        var retval = JsonConvert.SerializeObject(this);
        return retval;
    }
}