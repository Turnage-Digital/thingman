namespace ThingMan.Domain.Dtos;

public record PropDefDto
{
    public string Name { get; set; } = null!;
    public string PropType { get; set; } = null!;
}