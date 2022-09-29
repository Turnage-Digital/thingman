using Boogops.Core.Queries;
using Newtonsoft.Json;

namespace Boogops.Core.Store.Queries;

public class Query : IQuery
{
    [JsonProperty("TraceId")]
    public Guid TraceId { get; set; } = Guid.NewGuid();

    public override string ToString()
    {
        var retval = JsonConvert.SerializeObject(this);
        return retval;
    }
}