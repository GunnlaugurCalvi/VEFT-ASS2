using System.Collections.Generic;
using System.Linq;
using CoursesApi.Models.DTOModels;
using CoursesApi.Models.EntityModels;
using CoursesApi.Models.viewModels;

namespace CoursesApi.Services
{
    public interface IStudentsService
    {
        List<string> GetStudents();
        IEnumerable<StudentsDTO> GetStudentsInCourse(int id);

        StudentTemplate AddStudent(StudentTemplate newStudent, int id);
        
    }
}
