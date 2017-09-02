using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursesApi.Services;
using CoursesApi.Repositories;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {

        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }
        // GET api/students
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentsService.GetStudents();

            return Ok(students);
        }
    }
}
