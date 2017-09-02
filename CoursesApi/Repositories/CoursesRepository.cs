using System.Collections.Generic;
using CoursesApi.Models.DTOModels;
using System.Linq;
using System;

namespace CoursesApi.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly AppDataContext _db;


        public CoursesRepository(AppDataContext db)
        {
            _db = db;
        }


        public IEnumerable<CourseDTO> GetCourses()
        {
            var courses = (from c in _db.Courses
                select new CourseDTO
                {
                    ID = c.ID,
                    Name = c.Name,
                    CourseID = c.CourseID,
                    Semester = c.Semester

                }).ToList();

            return courses;
        }
    }
}
