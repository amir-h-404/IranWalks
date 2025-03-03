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
            // todo: get all regions from the database
            return Ok();
        }
    }
}
