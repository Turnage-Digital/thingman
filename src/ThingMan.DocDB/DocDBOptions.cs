namespace ThingMan.DocDB;

public class DocDBOptions
{
    public string? Account { get; set; }

    public string? Key { get; set; }
    
    public string? DatabaseName { get; set; } = "ThingMan";
    
    public string? ThingDefsContainerName { get; set; } = "ThingDefs";
    
    public string? ThingDefsPartitionKey { get; set; } = "/UserId";
}