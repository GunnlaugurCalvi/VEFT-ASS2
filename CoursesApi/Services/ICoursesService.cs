using System.Collections.Generic;
using CoursesApi.Models.DTOModels;
using CoursesApi.Models.EntityModels;
using CoursesApi.Models.viewModels;

namespace CoursesApi.Services
{
    public interface ICoursesService
    {
        IEnumerable<CourseDTO> GetCourses();
        IEnumerable<CourseDTOSemester> GetCoursesBySemester(int semester);
        IEnumerable<CourseDTODetail> GetCoursesById(int id);
        Course AddCourse(CourseTemplate course);
        Course UpdateCourse(Course upCourse, int id);
        Course DeleteCourse(Course delCourse, int id);



    }
}
