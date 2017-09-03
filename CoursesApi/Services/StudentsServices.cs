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


        public List<string> GetStudents()
        {
            var students = _repo.GetStudents();

            List<string> retValue =  new List<string>();            

            foreach(StudentsDTO s in students)
            {
                retValue.Add(s.Name);
            }
            return retValue;
        }

        public IEnumerable<StudentsDTO> GetStudentsInCourse(int id)
        {
            var studentsInCourse = _repo.GetStudentsInCourse(id);

            // List<string> retValue =  new List<string>();            

            // foreach(StudentsDTO s in studentsInCourse)
            // {
            //     retValue.Add(s.Name);
            // }
            return studentsInCourse;

        }
    }
}