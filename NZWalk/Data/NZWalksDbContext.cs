using Microsoft.EntityFrameworkCore;
using NZWalk.Models.Domain;

namespace NZWalk.Data;

public class NZWalksDbContext : DbContext
{
    public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    
    {
        
    }
    
    public DbSet<Difficulty> Difficulties { get; set; }

    public DbSet<Region> Regions { get; set; }
    
    public DbSet<Walk> Walks { get; set; }
}