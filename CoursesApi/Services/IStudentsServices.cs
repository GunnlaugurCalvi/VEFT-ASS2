using System.Collections.Generic;
using CoursesApi.Models.DTOModels;

namespace CoursesApi.Services
{
    public interface IStudentsService
    {
        IEnumerable<StudentsDTO> GetStudents();
    }
}
