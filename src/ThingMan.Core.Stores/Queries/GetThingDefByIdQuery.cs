namespace ThingMan.Core.Stores.Queries;

public class GetThingDefByIdQuery : Query
{
    public GetThingDefByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; }
}