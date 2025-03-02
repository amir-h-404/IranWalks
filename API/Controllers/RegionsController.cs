using API.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // URL => http://localhost:5089/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        // GET: URL => http://localhost:5089/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            Region[] regions = 
                [
                new Region 
                {
                    Id = Guid.NewGuid(),
                    Name = "Tehran Region",
                    Code = "THN",
                    RegionImageUrl = "https://en.wikipedia.org/wiki/Tehran#/media/File:North_of_Tehran_Skyline_view.jpg"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Mashhad Region",
                    Code = "MHD",
                    RegionImageUrl = "https://en.wikipedia.org/wiki/Mashhad#/media/File:Aerial_View_of_Koohsangi_street,_Mashhad,_Iran.png"
                }
                ];
            return Ok(regions);
        }
    }
}
