using System.Collections.Generic;
using CoursesApi.Models.DTOModels;
using System.Linq;
using System;

namespace CoursesApi.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly AppDataContext _db;


        public StudentsRepository(AppDataContext db)
        {
            _db = db;
        }
        
        public IEnumerable<StudentsDTO> GetStudents()
        {
            var students = (from c in _db.Students
                select new StudentsDTO
                {
                    ID = c.ID,
                    SSN = c.SSN,
                    Name = c.Name

                }).ToList();

            return students;
        }
    }
}
