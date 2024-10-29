using NZWalk.Models.Domain;
using NZWalk.Models.DTO;

namespace NZWalk.Repository;

public interface IRegionRepository
{
   Task<List<Region>> GetAllAsync();

   Task<Region?> GetByIdAsync(Guid id);
   
   Task<Region?> DeleteByIdAsync(Guid id);
   
   Task<Region?> UpdateByIdAsync(Guid id,Region region);
   
   Task<Region> CreateByIdAsync(Region region);
}