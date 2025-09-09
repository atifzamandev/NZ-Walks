using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZ_Walks.API.Data;
using NZ_Walks.API.Models.Domain;

namespace NZ_Walks.API.Controllers
{
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
            var regions = dbContext.Regions.ToList();
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRegionById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }

        [HttpGet("region-code")]
       // [Route("{code}")]
        public IActionResult GetRegionByCode([FromQuery] string code)
        {
            var regionCode = dbContext.Regions.FirstOrDefault(x => x.Code == code);

            if (regionCode == null)
            {
                return NotFound();
            }

            return Ok(regionCode);
        }


    }
}
