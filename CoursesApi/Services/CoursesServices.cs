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


        public IEnumerable<CourseDTOSemester> GetCoursesBySemester(string semester)
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

        public bool AddCourse(CourseTemplate course)
        {
            Course newCourse = new Course();
            if(GetNameAndID(course.CourseID) == null)
            {
                return false;
            }
            newCourse.Name = GetNameAndID(course.CourseID);
            newCourse.CourseID = course.CourseID;
            newCourse.Semester = course.Semester;
            newCourse.StartDate = course.StartDate;
            newCourse.EndDate = course.EndDate;

            bool retVal = _repo.AddCourse(newCourse);


            return retVal;
        }

        public CourseTemplate UpdateCourse(Course course, int id)
        {
            
          
            var upCourse = _repo.UpdateCourse(course, id);

            CourseTemplate updated = new CourseTemplate();

            updated.CourseID = upCourse.CourseID;
            updated.Semester = upCourse.Semester;
            updated.StartDate = upCourse.StartDate;
            updated.EndDate = upCourse.EndDate;

           return updated;
        }
        public CourseTemplate DeleteCourse(Course delCourse, int id)
        {
            var rem = _repo.DeleteCourse(delCourse, id);

            CourseTemplate deleted = new CourseTemplate();

            deleted.CourseID = rem.CourseID;
            deleted.Semester = rem.Semester;
            deleted.StartDate = rem.StartDate;
            deleted.EndDate = rem.EndDate;


            return deleted;
        }


    }
}