using API.Data;
using API.Models.Domain;
using API.Models.DTO;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // URL => http://localhost:5089/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IranWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepo;

        public RegionsController(IranWalksDbContext dbContext, 
            IRegionRepository regionRepository)
        {
            _dbContext = dbContext;
            _regionRepo = regionRepository;
        }

        // GET: URL => http://localhost:5089/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get data from database - Domain Model:
            var regionsDomain = await _regionRepo.GetAllAsync();
            // Map Domain Models to DTOs (Data Transfer Objects):
            List<RegionDto> regionDtos = [];
            foreach (var regionDomain in regionsDomain)
            {
                RegionDto regionDto = new()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                };
                regionDtos.Add(regionDto);
            }
            // Return DTOs:
            return Ok(regionDtos);
        }

        // GET: URL => http://localhost:5089/api/regions/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Region Domain Model from database:
            var regionDomain = await _regionRepo.GetByIdAsync(id);
            if (regionDomain == null) return NotFound();
            // Map Region Domain Model to Region DTO:
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            // Return DTO back to client:
            return Ok(regionDto);
        }

        // POST: URL => http://localhost:5089/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 
        AddRegionRequestDto addRegionRequestDto) 
        {
            // Map DTO to Domain Model:
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            // Use Domain Model to create Region:
            regionDomainModel = await _regionRepo
                .CreateAsync(regionDomainModel);
            // Map Domain Model back to DTO:
            var regionDto = new RegionDto 
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            // Return 201 Created:
            return CreatedAtAction(nameof(GetById), 
                new { id = regionDto.Id }, regionDto);
        }

        // PUT: URL => http://localhost:5089/api/regions/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, 
            [FromBody] UpdateRegionRequestDto updateRegionDto)
        {
            // Map DTO to Domain Model:
            var regionDomainModel = new Region 
            { 
                Code = updateRegionDto.Code,
                Name = updateRegionDto.Name,
                RegionImageUrl = updateRegionDto.RegionImageUrl
            };
            // Check if region exists:
            regionDomainModel = await _regionRepo
                .UpdateAsync(id, regionDomainModel);
            if (regionDomainModel == null) return NotFound();
            // Convert Domain Model to DTO:
            var regionDto = new RegionDto 
            { 
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return Ok(regionDto);
        }

        // DELETE: URL => http://localhost:5089/api/regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await _dbContext.Regions
                .FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null) return NotFound();
            // Remove Region:
            _dbContext.Regions.Remove(regionDomainModel);
            await _dbContext.SaveChangesAsync();
            // Map Domain Model to DTO:
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            // Return deleted Region back:
            return Ok(regionDto);
        }
    }
}
