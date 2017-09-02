using System.Collections.Generic;
using CoursesApi.Models.DTOModels;
using CoursesApi.Models.EntityModels;
using CoursesApi.Models.viewModels;
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
                    //ID = c.ID,
                    Name = c.Name
                    //CourseID = c.CourseID,
                    //Semester = c.Semester

                }).ToList();

            return courses;
        }

        public IEnumerable<CourseDTOSemester> GetCoursesBySemester(int Semester)
        {

            var coursesBySemester = (from c in _db.Courses
                where c.Semester == Semester
                select new CourseDTOSemester
                {
                    //ID = c.ID,
                    //Name = c.Name,
                    CourseID = c.CourseID,
                    //Semester = c.Semester     

                } ).ToList();
            return coursesBySemester;
        }

        public IEnumerable<CourseDTODetail> GetCoursesById(int id)
        {

            var coursesById = (from c in _db.Courses
                where c.ID == id
                select new CourseDTODetail
                {
                    //ID = c.ID,
                    Name = c.Name,
                    CourseID = c.CourseID,
                    Semester = c.Semester

                } ).ToList();

            return coursesById;
        }

        public IEnumerable<CourseDTODetail> GetAllCourseNames()
        {
            var AllCourses = (from c in _db.Courses
                select new CourseDTODetail
                {
                    Name = c.Name,
                    CourseID = c.CourseID,
                } ).ToList();

            return AllCourses;
        }
        public Course AddCourse(Course course)
        {
            _db.Courses.Add(course);
            
            _db.SaveChanges();
            return course;
        }
    }
}
