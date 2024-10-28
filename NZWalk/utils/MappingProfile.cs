using AutoMapper;
using NZWalk.Models.Domain;
using NZWalk.Models.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // บอก AutoMapper ว่าต้องการ map จาก Region ไปยัง RegionDto
        CreateMap<Region, RegionDto>();
    }
}