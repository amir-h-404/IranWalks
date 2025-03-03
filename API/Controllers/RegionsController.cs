﻿using API.Data;
using API.Models.Domain;
using API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // URL => http://localhost:5089/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IranWalksDbContext _dbContext;

        public RegionsController(IranWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: URL => http://localhost:5089/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            // Get data from database - Domain Model:
            var regionsDomain = _dbContext.Regions.ToList();
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

        // GET: URL => http://localhost:5089/api/regions/id
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            // Get Region Domain Model from database:
            var regionDomain = _dbContext.Regions.FirstOrDefault(x => x.Id == id);
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
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto) 
        {
            // Map DTO to Domain Model:
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            return Ok();
        }
    }
}
