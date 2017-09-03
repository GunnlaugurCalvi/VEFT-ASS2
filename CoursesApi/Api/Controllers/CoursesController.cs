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
    [Route("api/courses")]
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

         // GET api/courses/{id:int}
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
            Course retVal = _coursesService.AddCourse(course);

            if(retVal.Name == null)
            {
                return NotFound("Course " + retVal.CourseID +" does not exist"); // NotFound 404 ; 
            }else if( retVal.Name == "AlreadyExists")
            {
                return StatusCode(409); // Dublicate 409
            }

            return CreatedAtRoute("GetCourseById", new {ID = retVal.ID}, course); // Created 201
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCourse([FromBody] Course updatedCourse, int id)
       {
           //muna checka if updatecourse er null og id ekki sama == 400
           var course = _coursesService.GetCoursesById(id).SingleOrDefault();
           if(course == null)
           {
               return StatusCode(404); //NATFOUND
           }
           var upCourse = _coursesService.UpdateCourse(updatedCourse, id);

           return StatusCode(204);
          
       }

       [HttpDelete("{id:int}")]
       public IActionResult DeleteCourse(Course delCourse, int id)
       {
           var course = _coursesService.GetCoursesById(id).SingleOrDefault();

           if(course == null)
           {
               return StatusCode(404);
           }

           _coursesService.DeleteCourse(delCourse, id);

           return StatusCode(204);
       }


        
    }
}
