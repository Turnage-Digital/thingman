namespace ThingMan.Core.Domain.Queries;

public class GetThingDefByIdQuery : Query
{
    public GetThingDefByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; }
}