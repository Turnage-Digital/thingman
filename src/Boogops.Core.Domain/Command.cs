using Boogops.Core.Commands;
using Newtonsoft.Json;

namespace Boogops.Core.Domain;

public class Command : ICommand
{
    [JsonProperty("TraceId")]
    public Guid TraceId { get; set; } = Guid.NewGuid();

    public override string ToString()
    {
        var retval = JsonConvert.SerializeObject(this);
        return retval;
    }
}