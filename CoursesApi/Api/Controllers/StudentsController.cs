using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursesApi.Services;
using CoursesApi.Repositories;

namespace Api.Controllers
{
    [Route("api/courses")]
    public class StudentsController : Controller
    {

        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }
        // GET api/courses/students
        [HttpGet("[controller]")]
        public IActionResult GetStudents()
        {
            var students = _studentsService.GetStudents();

            if(students == null)
            {
                return NotFound("Database Empty"); // NotFound 404
            }

            return Ok(students);
        }


        [HttpGet("{id:int}/[controller]")]
        public IActionResult GetStudentsInCourse(int id)
        {
            
            var studentsInCourse = _studentsService.GetStudentsInCourse(id);

            if(studentsInCourse == null)
            {
                return NotFound("No student found"); // NotFound 404 ;
            }

            return Ok(studentsInCourse);
        }
    }
}
