namespace ThingMan.Domain.Aggregates.ThingDefs.Dtos;

public record ThingDefDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public PropDefDto? PropDef1 { get; set; }
    public PropDefDto? PropDef2 { get; set; }
    public PropDefDto? PropDef3 { get; set; }
}