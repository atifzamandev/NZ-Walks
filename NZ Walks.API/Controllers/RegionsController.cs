using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZ_Walks.API.Data;
using NZ_Walks.API.Models.Domain;
using NZ_Walks.API.Models.DTO;
using NZ_Walks.API.Repositories;

namespace NZ_Walks.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController:ControllerBase
        {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
            {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
            {
            var regionsDomain = await regionRepository.GetAllRegionsAsync();
            return Ok(mapper.Map<List<RegionsDto>>(regionsDomain));
            }

        [HttpGet]
        [Route("{id:guid}")]
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
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
            {

            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            regionDomainModel = await regionRepository.CreateRegionAsync(regionDomainModel);

            var regionDto = mapper.Map<RegionsDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetRegionById), new { regionDto.Id }, regionDto);

            }

        [HttpPut]
        [Route("{id:Guid}")]
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
        public async Task<IActionResult> DeleteRegionAsync([FromRoute] Guid id)
            {
            var regionDomainModel = await regionRepository.DeleteRegionAsync(id);

            if(regionDomainModel == null) return NotFound();

            var regionDto = mapper.Map<RegionsDto>(regionDomainModel);

            return Ok(regionDto);

            }

        }
    }
