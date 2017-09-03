using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursesApi.Services;
using CoursesApi.Repositories;
using CoursesApi.Models.EntityModels;
using CoursesApi.Models.DTOModels;
using CoursesApi.Models.viewModels;

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

        /// <summary>
        /// (BONUS CLASS)
        /// GET api/courses/students
        /// Gets all unique registered students
        /// </summary>
        [HttpGet("students")]
        public IActionResult GetStudents()
        {
            var students = _studentsService.GetStudents();

            if(students == null)
            {
                return NotFound("Database Empty"); // NotFound 404
            }

            return Ok(students);
        }

        /// <summary>
        /// GET api/courses/{id:int}/students
        /// Gets students in specific course
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SSN and name</returns>
        [HttpGet("{id:int}/students", Name="GetStudentsInCourse")]
        public IActionResult GetStudentsInCourse(int id)
        {
            
            var studentsInCourse = _studentsService.GetStudentsInCourse(id);

            if(studentsInCourse == null)
            {
                return NotFound("No student found"); // NotFound 404 ;
            }

            return Ok(studentsInCourse);
        }

        /// <summary>
        /// Adds a student to specific course
        /// </summary>
        /// <param name="student"></param>
        /// <param name="id"></param>
        /// <returns>SSN and name</returns>
        [HttpPost("{id:int}/students")]
        public IActionResult AddStudent([FromBody] StudentTemplate student, int id)
        {
            var added = _studentsService.AddStudent(student, id);
            
            return Created("GetStudentsInCourse", added);
        }
    }
}
