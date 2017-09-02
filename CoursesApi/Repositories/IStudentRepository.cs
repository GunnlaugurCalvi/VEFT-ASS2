using System.Collections.Generic;
using CoursesApi.Models.DTOModels;

namespace CoursesApi.Repositories
{
    public interface IStudentsRepository
    {
        IEnumerable<StudentsDTO> GetStudents();
    }

}