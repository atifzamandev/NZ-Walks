using Microsoft.AspNetCore.Mvc;
using NZ_Walks.API.Data;
using NZ_Walks.API.Models.Domain;
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

        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {

            var regionDomainModel = new Region()
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            };

            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            var regionDto = new RegionsDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetRegionById), new { regionDto.Id }, regionDto);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto ) 
        {

            var regionDomainModel = dbContext.Regions.FirstOrDefault(r => r.Id == id);

            if (regionDomainModel == null) return NotFound();

            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            dbContext.SaveChanges();

            var regionDto = new RegionsDto()
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
        public IActionResult delete([FromRoute] Guid id) 
        {
            var regionDomainModel = dbContext.Regions.FirstOrDefault(r => r.Id == id);

            if(regionDomainModel == null) return NotFound();

            dbContext.Regions.Remove(regionDomainModel);
            dbContext.SaveChanges();

            var regionDto = new RegionsDto() {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return Ok(regionDto);
        
        }

    }
}
