using Microsoft.AspNetCore.Mvc;
using NZ_Walks.API.Data;
using NZ_Walks.API.Models.DTO;

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
            var regionsDomain = dbContext.Regions.ToList();

            var regionsDto = new List<RegionsDto>();

            foreach (var regionDomain in regionsDomain)
            {

                regionsDto.Add(new RegionsDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl,

                });
            }
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRegionById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            var regionDomainById = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainById == null)
            {
                return NotFound();
            }

            var regionDto = new RegionsDto()
            {
                Id = regionDomainById.Id,
                Code = regionDomainById.Code,
                Name = regionDomainById.Name,
                RegionImageUrl = regionDomainById.RegionImageUrl,

            };
            return Ok(regionDto);
        }

        [HttpGet("region-code")]
        // [Route("{code}")]
        public IActionResult GetRegionByCode([FromQuery] string code)
        {
            var regionByCode = dbContext.Regions.FirstOrDefault(x => x.Code == code);

            if (regionByCode == null)
            {
                return NotFound();
            }


            var regionDto = new RegionsDto()
            {
                Id = regionByCode.Id,
                Code = regionByCode.Code,
                Name = regionByCode.Name,
                RegionImageUrl = regionByCode.RegionImageUrl,
            };

            return Ok(regionDto);
        }


    }
}
