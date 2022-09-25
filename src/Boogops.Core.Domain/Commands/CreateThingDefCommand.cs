using Boogops.Core.Commands;
using Newtonsoft.Json;

namespace Boogops.Core.Domain.Commands;

public class CreateThingDefCommand : ICommand
{
    [JsonProperty("TraceId")]
    public Guid? TraceId { get; set; }

    public override string ToString()
    {
        var retval = JsonConvert.SerializeObject(this);
        return retval;
    }
}