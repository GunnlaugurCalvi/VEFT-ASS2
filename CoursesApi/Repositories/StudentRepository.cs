using System.Collections.Generic;
using CoursesApi.Models.DTOModels;
using System.Linq;
using System;
using CoursesApi.Models.EntityModels;
using CoursesApi.Models.viewModels;

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
                .Distinct()
                select new StudentsDTO
                {
                    SSN = c.SSN,
                    Name = c.Name

                }).ToList();

            return students;
        }

        public IEnumerable<StudentsDTO> GetStudentsInCourse(int id)
        {
            var students = (from s in _db.Students
                            join C in _db.Courses on s.StudentCourseID equals C.ID
                            where s.StudentCourseID == id
                            select new StudentsDTO
                            {
                             SSN = s.SSN,
                             Name = s.Name

                            }).ToList();

            return students;
        }

        public Student AddStudent(Student newStudent)
        {
            _db.Students.Add(newStudent);
            _db.SaveChanges();
            return newStudent;
        }
    }
}
