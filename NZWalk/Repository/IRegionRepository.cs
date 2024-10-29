using NZWalk.Models.Domain;

namespace NZWalk.Repository;

public interface IRegionRepository
{
   Task<List<Region>> GetAllAsync();
}