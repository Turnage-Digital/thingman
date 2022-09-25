namespace Boogops.Core.Queries;

public class QueryResult<T>
{
    private readonly List<CoreError> _errors = new();

    public T? Result { get; init; }

    public bool Succeeded { get; init; }

    public IEnumerable<CoreError> Errors => _errors;

    public static QueryResult<T> Success { get; } = new() { Succeeded = true };

    public static QueryResult<T> CreateSuccessfulResult(T result)
    {
        var retval = new QueryResult<T>
        {
            Result = result,
            Succeeded = true
        };
        return retval;
    }

    public static QueryResult<T> CreateFailedResult(params CoreError[] errors)
    {
        var retval = new QueryResult<T> { Succeeded = false };
        retval._errors.AddRange(errors);
        return retval;
    }
}