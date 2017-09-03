using System.Collections.Generic;
using System.Linq;
using CoursesApi.Models.DTOModels;
using CoursesApi.Models.EntityModels;
using CoursesApi.Models.viewModels;

namespace CoursesApi.Repositories
{
    public interface IStudentsRepository
    {
        IEnumerable<StudentsDTO> GetStudents();
        IEnumerable<StudentsDTO> GetStudentsInCourse(int id);
        Student AddStudent(Student newStudent);
    }

}