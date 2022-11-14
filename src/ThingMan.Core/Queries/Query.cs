using Newtonsoft.Json;

namespace ThingMan.Core.Queries;

public abstract class Query : IQuery
{
    [JsonProperty("traceId")]
    public Guid TraceId { get; set; } = Guid.NewGuid();

    public override string ToString()
    {
        var retval = JsonConvert.SerializeObject(this);
        return retval;
    }
}