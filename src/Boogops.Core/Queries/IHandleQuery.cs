namespace Boogops.Core.Queries;

public interface IHandleQuery
{
    public string Name { get; }
}

public interface IHandleQuery<in TQuery, TResult> : IHandleQuery
{
    Task<QueryResult<TResult>> HandleAsync(TQuery query);
}