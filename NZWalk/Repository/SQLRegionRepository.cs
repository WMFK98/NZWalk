using Microsoft.EntityFrameworkCore;
using NZWalk.Data;
using NZWalk.Models.Domain;

namespace NZWalk.Repository;

public class SQLRegionRepository : IRegionRepository
{
    private readonly NZWalksDbContext dbContext;
    public SQLRegionRepository(NZWalksDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<Region>> GetAllAsync()
    {
       return await dbContext.Regions.ToListAsync();
    }
}