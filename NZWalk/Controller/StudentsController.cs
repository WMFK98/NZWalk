using Microsoft.AspNetCore.Mvc;

namespace NZWalks.Controller;
[Route("/api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{


        [HttpGet]
        public IActionResult GetAllStudents()
        {
                string[] studentName = new string[] { "fluke" };
                return Ok(studentName);
        }

}