namespace ThingMan.Core.Queries;

// I'm trying this name out. 🤣
public interface IAwaitQuery
{
    public string Name { get; }
}

public interface IAwaitQuery<in T, TResult> : IAwaitQuery
    where T : IQuery
{
    Task<CoreResponse<TResult>> AwaitAsync(T query);
}