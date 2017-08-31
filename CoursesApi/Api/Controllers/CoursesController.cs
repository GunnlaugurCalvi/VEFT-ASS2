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
    public class CoursesController : Controller
    {

        private readonly ICoursesService _coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = _coursesService.GetCourses();

            return Ok(courses);
        }
    }
}
