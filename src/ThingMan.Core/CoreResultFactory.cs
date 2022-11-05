namespace ThingMan.Core;

public static class CoreResultFactory
{
    public static CoreResult CreateFailedResult(params CoreError[] errors)
    {
        var retval = new CoreResult { Succeeded = false };
        retval._errors.AddRange(errors);
        return retval;
    }
}