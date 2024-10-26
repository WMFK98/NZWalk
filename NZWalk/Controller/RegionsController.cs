using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalk.Data;
using NZWalk.Models.Domain;

namespace NZWalks.Controller;

[Route("api/[controller]")]
[ApiController]
public class RegionsController : ControllerBase

{

    private readonly NZWalksDbContext dbContext;

    public RegionsController(NZWalksDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    
    [HttpGet]
    public IActionResult GetAllRegions()
    {
      var regions =  dbContext.Regions.ToList();
        return Ok(regions);
    }

}