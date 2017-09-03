using System.Collections.Generic;
using CoursesApi.Models.DTOModels;

namespace CoursesApi.Services
{
    public interface IStudentsService
    {
        List<string> GetStudents();
        IEnumerable<StudentsDTO> GetStudentsInCourse(int id);
    }
}
