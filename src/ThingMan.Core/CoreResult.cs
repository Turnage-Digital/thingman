namespace ThingMan.Core;

public class CoreResult
{
    internal readonly List<CoreError> _errors = new();

    public bool Succeeded { get; init; }

    public IEnumerable<CoreError> Errors => _errors;

    public static CoreResult Success { get; } = new() { Succeeded = true };
}