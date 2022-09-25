namespace Boogops.Core.Queries;

public interface IQuery
{
    Guid TraceId { get; set; }
}