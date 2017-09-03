using System.Collections.Generic;
using CoursesApi.Models.DTOModels;
using CoursesApi.Models.EntityModels;
using CoursesApi.Models.viewModels;

namespace CoursesApi.Services
{
    public interface ICoursesService
    {
        IEnumerable<CourseDTO> GetCourses();
        IEnumerable<CourseDTOSemester> GetCoursesBySemester(string semester);
        IEnumerable<CourseDTODetail> GetCoursesById(int id);
        bool AddCourse(CourseTemplate course);
        CourseTemplate UpdateCourse(Course upCourse, int id);
        CourseTemplate DeleteCourse(Course delCourse, int id);



    }
}
