using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalk.Data;
using NZWalk.Models.Domain;
using NZWalk.Models.DTO;
using NZWalk.Repository;

namespace NZWalks.Controller;

[Route("api/[controller]")]
[ApiController]
public class RegionsController : ControllerBase



{
    private readonly IMapper _mapper;

    private readonly NZWalksDbContext dbContext;
    private readonly IRegionRepository regionRepository;

    public RegionsController(NZWalksDbContext dbContext,IRegionRepository regionRepository)
    {
        this.dbContext = dbContext;
        this.regionRepository = regionRepository;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAllRegions()
    {
      var regionsDomain = await regionRepository.GetAllAsync();
      var regionsDto = new List<RegionDto>();

      foreach (var regionDomain in regionsDomain)
      {
          regionsDto.Add(new RegionDto()
          {
              Id = regionDomain.Id,
              Code = regionDomain.Code,
              Name = regionDomain.Name,
              RegionImageUrl = regionDomain.RegionImageUrl,
          });
          
      }
      
      // var regions = _mapper.Map<List<Region>, List<RegionDto>>(regionsDomain);
        return Ok(regionsDto);
    }


    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
    {
       // var region =  dbContext.Regions.Find(id);
       var regionDomain = await dbContext.Regions.FirstOrDefaultAsync( x => x.Id == id );
       if (regionDomain == null) return NotFound();
      var regionDto =  new RegionDto()
       {
           Id = regionDomain.Id,
           Code = regionDomain.Code,
           Name = regionDomain.Name,
           RegionImageUrl = regionDomain.RegionImageUrl,
       };
       return Ok(regionDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
    {

        var regionDomain = new Region()
        {
            Code = addRegionRequestDto.Code,
            Name = addRegionRequestDto.Name,
            RegionImageUrl = addRegionRequestDto.RegionImageUrl
        };

        await dbContext.Regions.AddAsync(regionDomain);
        await dbContext.SaveChangesAsync();

        var newRegionDto = new RegionDto()
        {
            Id = regionDomain.Id,
            Code = regionDomain.Code,
            Name = regionDomain.Name,
            RegionImageUrl = regionDomain.RegionImageUrl,
        };
        
        return CreatedAtAction(nameof(GetRegionById), new {id = newRegionDto.Id}, newRegionDto);
        // var regionDomain =  _mapper.Map<Region>(addRegionRequestDto);

    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto )
    {
      var regionDomainModel = await  dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
      
      if(regionDomainModel == null) return NotFound();
      
      regionDomainModel.Code = updateRegionRequestDto.Code;
      regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
      regionDomainModel.Name = updateRegionRequestDto.Name;

      await dbContext.SaveChangesAsync();

      var regionDto = new RegionDto()
      {
          Id = regionDomainModel.Id,
          Code = regionDomainModel.Code,
          Name = regionDomainModel.Name,
          RegionImageUrl = regionDomainModel.RegionImageUrl,
      };
      
      return Ok(regionDto);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public  IActionResult DeleteRegion([FromRoute] Guid id)
    {
        var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);
        if (regionDomainModel == null) return NotFound();
        dbContext.Regions.Remove(regionDomainModel);
        dbContext.SaveChanges();

        var regionDto = new RegionDto()
        {
            Id = regionDomainModel.Id,
            Name = regionDomainModel.Name,
            RegionImageUrl = regionDomainModel.RegionImageUrl,
        };

        return Ok(regionDto);

    }
    
    

}