using System.Collections.Generic;
using CoursesApi.Models.DTOModels;
using CoursesApi.Repositories;
using CoursesApi.Models.EntityModels;
using CoursesApi.Models.viewModels;


namespace CoursesApi.Services
{
    public class CoursesServices : ICoursesService
    {
        private readonly ICoursesRepository _repo;

        public CoursesServices(ICoursesRepository repo)
        {
            _repo = repo;
        }
 

        public IEnumerable<CourseDTO> GetCourses()
        {
            var courses = _repo.GetCourses();
            return courses;
        }


        public IEnumerable<CourseDTOSemester> GetCoursesBySemester(int semester)
        {
            var coursesBySemester = _repo.GetCoursesBySemester(semester);
            return coursesBySemester;
        }

        public IEnumerable<CourseDTODetail> GetCoursesById(int id)
        {
            var coursesById = _repo.GetCoursesById(id);
            return coursesById;
        }

       public string getAllCourseName(string CourseID)
       {
           IEnumerable<CourseDTODetail> list = _repo.GetAllCourseNames();

           foreach (CourseDTODetail C in list)
           {
               if(C.CourseID == CourseID)
               {
                   return C.Name;
               }
           }
           return null;
       }

       public Course AddCourse(CourseTemplate course)
       {
           Course newCourse = new Course();

           newCourse.Name = getAllCourseName(course.CourseID);
           newCourse.CourseID = course.CourseID;
           newCourse.Semester = course.Semester;
           newCourse.StartDate = course.StartDate;
           newCourse.EndDate = course.EndDate;

            var retVal = _repo.AddCourse(newCourse);

           return retVal;
       }
    }
}