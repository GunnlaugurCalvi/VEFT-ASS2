using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursesApi.Services;
using CoursesApi.Repositories;
using CoursesApi.Models.EntityModels;
using CoursesApi.Models.viewModels;

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
        
        // GET api/courses
        [HttpGet("")]
        public IActionResult GetCourses()
        {
            var courses = _coursesService.GetCourses();

            return Ok(courses);
        }
        
        // GET api/courses?semester={Semester:int}
        [HttpGet("semester={Semester:int}")]
        public IActionResult GetCoursesBySemester(int Semester)
        {
            var courses = _coursesService.GetCoursesBySemester(Semester);

            return Ok(courses);
        }

         // GET api/courses?semester={Semester:int}
        [HttpGet("{id:int}", Name = "GetCourseById")]
        public IActionResult GetCoursesById(int id)
        {
            var courses = _coursesService.GetCoursesById(id).SingleOrDefault();

            if(courses == null)
            {
                return NotFound("Course Id " + id + " does not exist");
            }

            return Ok(courses);
        }

        [HttpPost("")]
        public IActionResult AddCourse([FromBody] CourseTemplate course)
        {
            var retVal = _coursesService.AddCourse(course);


            return CreatedAtRoute("GetCourseById", new { id = retVal.ID }, retVal); // Created
        }
    }
}
