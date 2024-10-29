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
    private readonly IMapper mapper;
    private readonly NZWalksDbContext dbContext;
    private readonly IRegionRepository regionRepository;

    public RegionsController(NZWalksDbContext dbContext,IRegionRepository regionRepository,IMapper mapper)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
        this.regionRepository = regionRepository;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAllRegions()
    {
      var regionsDomain = await regionRepository.GetAllAsync();
        return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
    }


    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
    {
       // var region =  dbContext.Regions.Find(id);
       var regionDomain = await regionRepository.GetByIdAsync(id);
       if (regionDomain == null) return NotFound();
       return Ok(mapper.Map<RegionDto>(regionDomain));
    }

    [HttpPost]
    public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        var regionDomain = mapper.Map<Region>(addRegionRequestDto);
        regionDomain = await regionRepository.CreateByIdAsync(regionDomain);
        
        return CreatedAtAction(nameof(GetRegionById), new {id = regionDomain.Id}, regionDomain);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto )
    {

        var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
      regionDomainModel = await regionRepository.UpdateByIdAsync(id, regionDomainModel);
      if(regionDomainModel == null) return NotFound();
      
      return Ok(mapper.Map<RegionDto>(regionDomainModel));
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
    {
        var regionDomainModel = await regionRepository.DeleteByIdAsync(id);
        if (regionDomainModel == null) return NotFound();
        
        return Ok(mapper.Map<RegionDto>(regionDomainModel));

    }
    
    

}