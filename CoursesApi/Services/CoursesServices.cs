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

       public string GetNameAndID(string CourseID)
       {
           IEnumerable<CourseDTODetail> list = _repo.GetNameAndID();

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

           newCourse.Name = GetNameAndID(course.CourseID);
           newCourse.CourseID = course.CourseID;
           newCourse.Semester = course.Semester;
           newCourse.StartDate = course.StartDate;
           newCourse.EndDate = course.EndDate;

            Course retVal = _repo.AddCourse(newCourse);

           return retVal;
       }

        // public int CountStudents(string CourseID)
        // {
        //     int count = _repo.CountStudents(CourseID);

        //     return count;
        // }

               public Course UpdateCourse(Course Course, int id)
       {
          
           var upCourse = _repo.UpdateCourse(Course, id);

           return upCourse;
       }
       public Course DeleteCourse(Course delCourse, int id)
       {
           var rem = _repo.DeleteCourse(delCourse, id);

           return delCourse;
       }


    }
}