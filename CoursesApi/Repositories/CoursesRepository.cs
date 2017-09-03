﻿using System.Collections.Generic;
using CoursesApi.Models.DTOModels;
using CoursesApi.Models.EntityModels;
using CoursesApi.Models.viewModels;
using System.Linq;
using System;

namespace CoursesApi.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly AppDataContext _db;


        public CoursesRepository(AppDataContext db)
        {
            _db = db;
        }

        public IEnumerable<CourseDTO> GetCourses()
        {
            var courses = (from c in _db.Courses
                        where c.Semester == 20173
                        select new CourseDTO
                        {
                            Name = c.Name

                        }).ToList();

            return courses;
        }

        public IEnumerable<CourseDTOSemester> GetCoursesBySemester(int Semester)
        {

            var coursesBySemester = (from c in _db.Courses
                where c.Semester == Semester
                select new CourseDTOSemester
                {
                    CourseID = c.CourseID
                 
                } ).ToList();
            return coursesBySemester;
        }

        public IEnumerable<CourseDTODetail> GetCoursesById(int id)
        {

            var coursesById = (from c in _db.Courses
                where c.ID == id
                select new CourseDTODetail
                {
                    //ID = c.ID,
                    Name = c.Name,
                    CourseID = c.CourseID,
                    Semester = c.Semester,
                    StudentCount = CountStudents(id)
                } ).ToList();

            return coursesById;
        }

        public IEnumerable<CourseDTODetail> GetNameAndID()
        {
            var AllCourses = (from c in _db.Courses
                select new CourseDTODetail
                {
                    Name = c.Name,
                    CourseID = c.CourseID,
                } ).ToList();

            return AllCourses;
        }
        public bool AddCourse(Course course)
        {
            IList<Course> list = (from c in _db.Courses
                select new Course
                {
                    Semester = c.Semester,
                    CourseID = c.CourseID,
                } ).ToList();

            foreach (Course l in list)
            {
                if(l.CourseID == course.CourseID && l.Semester == course.Semester)
                {
                   
                    return false;
                }
            }


            _db.Courses.Add(course);
            
            _db.SaveChanges();

            return true;
        }

        public Course UpdateCourse(Course upCourse, int id)
       {
          
          
           List<Course> res = (from c in _db.Courses
                               where c.ID == id
                               select c).ToList();

           foreach(var c in res)
           {
               c.EndDate = upCourse.EndDate;
               c.StartDate = upCourse.StartDate;
           }
          
           _db.SaveChanges();
          
           return upCourse;
       }

       public Course DeleteCourse(Course delCourse ,int id)
       {
           var rem = (from r in _db.Courses
                           where r.ID == id
                           select r).FirstOrDefault();
          
           if(rem != null)
           {
               _db.Courses.Remove(rem);
               _db.SaveChanges();
           }
         
           return rem;   
       }

       int CountStudents(int id)
       {
            var count = (from s in _db.Students
                            join C in _db.Courses on s.StudentCourseID equals C.ID
                            where C.ID == id
                            select s ).Count();
            return count;
        }
    }
}
