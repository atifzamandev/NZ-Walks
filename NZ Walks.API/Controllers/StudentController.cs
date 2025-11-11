using Microsoft.AspNetCore.Mvc;

namespace NZ_Walks.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController:ControllerBase
        {
        [HttpGet]
        public IActionResult GetAllStudents()
            {
            string[] studentNames = new string[] { "Atif", "Kashif", "Zaman" };

            return Ok(studentNames);
            }
        }
    }