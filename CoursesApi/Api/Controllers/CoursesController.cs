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
        
        
        /// <summary>
        /// GET api/courses 
        /// Gets all the courses that is this semester 
        /// in the database
        /// </summary>
        /// <returns> Courses </returns>
        [HttpGet("")]
        public IActionResult GetCourses()
        {
            var courses = _coursesService.GetCourses();

            return Ok(courses);
        }
        
        
        /// <summary>
        ///  GET api/courses/semester={Semester:string}
        ///  This class will get the courses that 
        ///  match specific semester 
        /// </summary>
        /// <param name="Semester"></param>
        /// <returns> Courses </returns>
        [HttpGet("semester={semester}")]
        public IActionResult GetCoursesBySemester(string semester)
        {
            var courses = _coursesService.GetCoursesBySemester(semester);

            return Ok(courses);
        }

         /// <summary>
         /// This class will get the courses that 
         /// matches specifc id and with more detailed  
         /// object describing.
         /// If course instance is not found it returns statuscode:404
         /// </summary>
         /// <param name="id"></param>
         /// <returns>
         /// More detailed information about specific course.
         /// statuscode:404 if not found
         /// </returns>
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
        /// <summary>
        /// (BONUS CLASS)
        /// This class allows the client of API to add an course
        /// that is in the database 
        /// </summary>
        /// <param name="course"></param>
        /// <returns>a new course for new semester</returns>
        [HttpPost("")]
        public IActionResult AddCourse([FromBody] CourseTemplate course)
        {
            bool retVal = _coursesService.AddCourse(course);

            if(retVal == false)
            {
                return StatusCode(400); // Bad request
            }

            return Created("GetCourseById", course); // Created 201
        }

        /// <summary>
        /// This class allows the client of the API
        /// to modify the given course instance(StartDate, EndDate)
        /// If client tries to modify a course that is not found
        /// it returns statuscode:404
        /// </summary>
        /// <param name="updatedCourse"></param>
        /// <param name="id"></param>
        /// <returns>
        /// Modified Course.
        /// if not found statuscode: 404
        /// </returns>
        [HttpPut("{id:int}")]
        public IActionResult UpdateCourse([FromBody] Course updatedCourse, int id)
       {
           var course = _coursesService.GetCoursesById(id).SingleOrDefault();
           if(course == null)
           {
               return StatusCode(404); 
           }
           var upCourse = _coursesService.UpdateCourse(updatedCourse, id);

           return StatusCode(204);
          
       }
        /// <summary>
        /// This class should remove the specific course.
        /// If client tries to remove a course that cannot be found
        /// it returns statuscode: 404
        /// </summary>
        /// <param name="delCourse"></param>
        /// <param name="id"></param>
        /// <returns>
        /// statuscode: 204 
        /// if not than statuscode:404
        /// </returns>
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
