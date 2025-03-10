﻿using API.Models.Domain;
using API.Models.DTO;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // URL => http://localhost:5089/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepo;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, 
            IMapper mapper)
        {
            _regionRepo = regionRepository;
            _mapper = mapper;
        }

        // GET: URL => http://localhost:5089/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get data from database - Domain Models:
            var regionsDomain = await _regionRepo.GetAllAsync();
            // Map Domain Models to DTOs (Data Transfer Objects) and return DTOs:
            return Ok(_mapper.Map<List<RegionDto>>(regionsDomain));
        }

        // GET: URL => http://localhost:5089/api/regions/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Region Domain Model from database:
            var regionDomain = await _regionRepo.GetByIdAsync(id);
            if (regionDomain == null) return NotFound();
            // Map Region Domain Model to DTO and return DTO back to client:
            return Ok(_mapper.Map<RegionDto>(regionDomain));
        }

        // POST: URL => http://localhost:5089/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] 
        AddRegionRequestDto addRegionRequestDto) 
        {
            // Map DTO to Domain Model:
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);
            // Use Domain Model to create Region:
            regionDomainModel = await _regionRepo.CreateAsync(regionDomainModel);
            if (regionDomainModel == null) return Ok("Region exists!");
            // Map Domain Model back to DTO:
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);
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
            var regionDomainModel = _mapper.Map<Region>(updateRegionDto);
            // Check if region exists:
            regionDomainModel = await _regionRepo
                .UpdateAsync(id, regionDomainModel);
            if (regionDomainModel == null) return NotFound();
            // Convert Domain Model to DTO and return data:
            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }

        // DELETE: URL => http://localhost:5089/api/regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepo.DeleteAsync(id);
            if (regionDomainModel == null) return NotFound();
            // Map Domain Model to DTO and return deleted Region back:
            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
