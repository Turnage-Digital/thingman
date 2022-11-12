namespace ThingMan.Core.Commands;

public interface IHandleCommand
{
    string Name { get; }
}

public interface IHandleCommand<in T> : IHandleCommand
    where T : ICommand
{
    Task<CoreResponse> HandleAsync(T command);
}

public interface IHandleCommand<in T, TResult> : IHandleCommand
    where T : ICommand
{
    Task<CoreResponse<TResult>> HandleAsync(T command);
}