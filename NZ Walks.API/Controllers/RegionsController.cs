using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZ_Walks.API.CustomActionFilters;
using NZ_Walks.API.Data;
using NZ_Walks.API.Models.Domain;
using NZ_Walks.API.Models.DTO;
using NZ_Walks.API.Repositories;
using System.Text.Json;

namespace NZ_Walks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController:ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)

        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllRegions()
        {
            try
            {
                var regionsDomain = await regionRepository.GetAllRegionsAsync();

                logger.LogInformation($"Region domain model data: {JsonSerializer.Serialize(regionsDomain)}");
                return Ok(mapper.Map<List<RegionsDto>>(regionsDomain));

            }
            catch(Exception ex)
            {
                logger.LogError(ex, "An error occurred in GetAllRegions: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        [HttpGet]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Reader")]

        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {

            var regionDomainById = await regionRepository.GetRegionByIdAsync(id);

            if(regionDomainById == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionsDto>(regionDomainById));
        }

        [HttpGet("region-code")]
        //[Authorize(Roles = "Reader")]

        public async Task<IActionResult> GetRegionByCode([FromQuery] string code)
        {
            var regionByCode = await regionRepository.GetRegionByCodeAsync(code);

            if(regionByCode == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionsDto>(regionByCode));
        }

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]

        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {

            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            regionDomainModel = await regionRepository.CreateRegionAsync(regionDomainModel);

            var regionDto = mapper.Map<RegionsDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetRegionById), new { regionDto.Id }, regionDto);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //   [Authorize(Roles = "Writer")]

        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel = await regionRepository.UpdateRegionAsync(id, regionDomainModel);

            if(regionDomainModel == null) return NotFound();

            var regionDto = mapper.Map<RegionsDto>(regionDomainModel);

            return Ok(regionDto);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Writer, Reader")]

        public async Task<IActionResult> DeleteRegionAsync([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteRegionAsync(id);

            if(regionDomainModel == null) return NotFound();

            var regionDto = mapper.Map<RegionsDto>(regionDomainModel);

            return Ok(regionDto);

        }

    }
}
