using AutoMapper;
using NZWalk.Models.Domain;
using NZWalk.Models.DTO;

namespace NZWalk.Mappings;

public class AutoMapperProfiles:Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Region, RegionDto>();
        CreateMap<AddRegionRequestDto, RegionDto>();
        CreateMap<UpdateRegionRequestDto, RegionDto>();
    }
}