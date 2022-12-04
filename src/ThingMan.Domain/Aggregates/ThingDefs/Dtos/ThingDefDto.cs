namespace ThingMan.Domain.Aggregates.ThingDefs.Dtos;

public record ThingDefDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public PropDefDto[] Props { get; set; } = null!;
}