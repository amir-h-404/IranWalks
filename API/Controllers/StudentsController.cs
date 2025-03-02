using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

// URL => http://localhost:5089/api/students
[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    // GET: URL => http://localhost:5089/api/students
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        // name of students comes from database:
        string[] students = ["Amirhossein", "Zahra", "Reyhaneh", "Mohsen"];
        return Ok(students);
    }
}

