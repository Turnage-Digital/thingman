namespace Boogops.Core.Queries;

// I'm trying this name out. 🤣
public interface IAwaitQuery
{
    public string Name { get; }
}

public interface IAwaitQuery<in TQuery, TResult> : IAwaitQuery
    where TQuery : IQuery
{
    Task<QueryResult<TResult>> AwaitAsync(TQuery query);
}