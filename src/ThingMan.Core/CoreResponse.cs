namespace ThingMan.Core;

public class CoreResponse<T> : CoreResponse
{
    public T? Result { get; init; }

    public static CoreResponse<T> CreateSuccessfulResponseWithResult(T result)
    {
        var retval = new CoreResponse<T>
        {
            Result = result,
            Succeeded = true
        };
        return retval;
    }

    public new static CoreResponse<T> CreateFailedResponse(params CoreError[] errors)
    {
        var retval = new CoreResponse<T> { Succeeded = false };
        retval._errors.AddRange(errors);
        return retval;
    }
}

public class CoreResponse
{
    internal readonly List<CoreError> _errors = new();

    public bool Succeeded { get; protected init; }

    public IEnumerable<CoreError> Errors => _errors;

    public static CoreResponse Success { get; } = new() { Succeeded = true };

    public static CoreResponse CreateFailedResponse(params CoreError[] errors)
    {
        var retval = new CoreResponse { Succeeded = false };
        retval._errors.AddRange(errors);
        return retval;
    }
}