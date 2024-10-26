namespace NZWalk.Models.Domain;

public class Difficulty
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Walk> Walks { get; set; } = new List<Walk>();
}