using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZ_Walks.API.Models.Domain;
using NZ_Walks.API.Models.DTO;
using NZ_Walks.API.Repositories;

namespace NZ_Walks.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController:ControllerBase
        {

        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
            {
            this.mapper = mapper;
            this.walkRepository = walkRepository;

            }

        [HttpPost]
        public async Task<IActionResult> CreateWalks([FromBody] AddWalkRequestDto addWalksRequestDto)
            {
            var walkDomainModel = mapper.Map<Walk>(addWalksRequestDto);

            await walkRepository.CreateWalkAsync(walkDomainModel);

            var walkDto = mapper.Map<WalkDto>(walkDomainModel);

            return CreatedAtAction(nameof(GetWalkById), new { walkDto.Id }, walkDto);
            }
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
            {
            var walksDomainModel = await walkRepository.GetAllWalksAsync();
            var walksDto = mapper.Map<List<WalkDto>>(walksDomainModel);
            return Ok(walksDto);
            }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
            {

            var walkDomainModel = await walkRepository.GetWalkByIdAsync(id);

            if(walkDomainModel == null) return NotFound();

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
            }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, UpdateWalkRequestsDto updateWalkRequestsDto)
            {
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestsDto);
            walkDomainModel = await walkRepository.UpdateWalkAsync(id, walkDomainModel);

            if(walkDomainModel == null) return NotFound();

            var walkDtoModel = mapper.Map<WalkDto>(walkDomainModel);
            return Ok(walkDtoModel);

            }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id)
            {
            var deletedWalkModel = await walkRepository.DeleteWalkAsync(id);

            if(deletedWalkModel == null) return NotFound();

            var deletedWalkDto = mapper.Map<WalkDto>(deletedWalkModel);

            return Ok(deletedWalkDto);

            }

        }
    }
