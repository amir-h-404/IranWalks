using API.Data;
using API.Models.Domain;
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
            var regions = _dbContext.Regions.ToList();
            // Map Domain Models to DTOs (Data Transfer Objects):
            // todo
            // Return DTOs:
            return Ok(regions);
        }

        // GET: URL => http://localhost:5089/api/regions/id
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            // var region = _dbContext.Regions.Find(id);
            var region = _dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (region == null) return NotFound();
            return Ok(region);
        }
    }
}
