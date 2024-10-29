using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalk.Data;
using NZWalk.Models.Domain;
using NZWalk.Models.DTO;

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

    public async Task<Region?> GetByIdAsync(Guid id)
    {
       var regionDomain = await this.dbContext.Regions.FindAsync(id);
       return regionDomain;
    }

    public async Task<Region?> DeleteByIdAsync(Guid id)
    {
        var existingRegion = await this.dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (existingRegion == null) return null;
        dbContext.Regions.Remove(existingRegion);
        await dbContext.SaveChangesAsync();
        return existingRegion;
    }

    public async Task<Region?> UpdateByIdAsync(Guid id, Region region)
    {
        var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (existingRegion == null) return null;
        
        existingRegion.Name = region.Name;
        existingRegion.Code = region.Code;
        existingRegion.RegionImageUrl = region.RegionImageUrl;

       await dbContext.SaveChangesAsync();

       return existingRegion;



    }
    
    public async Task<Region> CreateByIdAsync(Region region)
    {
        await dbContext.Regions.AddAsync(region);
        await dbContext.SaveChangesAsync();
        return region;
    }
}