namespace NZWalk.Models.Domain;

public class Region
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? RegionImageUrl { get; set; }
    
    // Navigation Property for related Walks
    public ICollection<Walk> Walks { get; set; } = new List<Walk>();
}