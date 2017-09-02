using System.Collections.Generic;
using CoursesApi.Models.DTOModels;
using CoursesApi.Repositories;


namespace CoursesApi.Services
{
    public class StudentsServices : IStudentsService
    {
        private readonly IStudentsRepository _repo;

        public StudentsServices(IStudentsRepository repo)
        {
            _repo = repo;
        }


        public IEnumerable<StudentsDTO> GetStudents()
        {
            var students = _repo.GetStudents();
            return students;
        }
    }
}