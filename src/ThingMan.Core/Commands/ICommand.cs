namespace ThingMan.Core.Commands;

public interface ICommand
{
    Guid TraceId { get; set; }
}