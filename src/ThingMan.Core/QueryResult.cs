namespace ThingMan.Core;

public class QueryResult<T>
{
    internal readonly List<CoreError> _errors = new();

    public T? Result { get; init; }

    public bool Succeeded { get; init; }

    public IEnumerable<CoreError> Errors => _errors;

    public static QueryResult<T> Success { get; } = new() { Succeeded = true };
}