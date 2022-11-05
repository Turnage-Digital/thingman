namespace ThingMan.Core;

public static class QueryResultFactory
{
    public static QueryResult<T> CreateSuccessfulResult<T>(T result)
    {
        var retval = new QueryResult<T>
        {
            Result = result,
            Succeeded = true
        };
        return retval;
    }

    public static QueryResult<T> CreateFailedResult<T>(params CoreError[] errors)
    {
        var retval = new QueryResult<T> { Succeeded = false };
        retval._errors.AddRange(errors);
        return retval;
    }
}