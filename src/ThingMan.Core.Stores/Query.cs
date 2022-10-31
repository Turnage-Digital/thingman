using ThingMan.Core.Queries;
using Newtonsoft.Json;

namespace ThingMan.Core.Stores;

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