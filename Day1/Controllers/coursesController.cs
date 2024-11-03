using Api_c180_Day1.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_c180_Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class coursesController : ControllerBase
    {
        public List<course> courses = new List<course>
        {
        new course { Id = 1, Name = "C++", Duration = 10, Status = true },
        new course { Id = 2, Name = "C#", Duration = 8, Status = false },
        new course { Id = 3, Name = "Sql", Duration = 12, Status = true }
        };

        [HttpGet]
        public List<course> GetAll()
        {
            return courses;
        }

        [HttpGet("{id}")]
        public course GetById(int id)
        {
            return courses.FirstOrDefault(c => c.Id == id);
        }


    }
}

