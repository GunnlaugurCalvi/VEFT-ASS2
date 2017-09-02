using System.Collections.Generic;
using CoursesApi.Models.DTOModels;
using CoursesApi.Models.EntityModels;
using CoursesApi.Models.viewModels;

namespace CoursesApi.Repositories
{
    public interface ICoursesRepository
    {
        IEnumerable<CourseDTO> GetCourses();
        IEnumerable<CourseDTOSemester> GetCoursesBySemester(int semester);
        IEnumerable<CourseDTODetail> GetCoursesById(int id);
        Course AddCourse(Course course);
        IEnumerable<CourseDTODetail> GetAllCourseNames();
    }

}